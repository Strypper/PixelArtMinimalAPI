using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PixelArtContext>(options => 
                                               options.UseSqlServer("Server=IDL-LT-091;Database=PixelArt;Persist Security Info=False;User ID=sa;Password=abc123;"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getDesigns", async (PixelArtContext context, CancellationToken cancellationToken) 
    => await context.Designs.ToListAsync(cancellationToken));

app.MapGet("/getDesign/{id}", async (PixelArtContext context, int id, CancellationToken cancellationToken) => {
    var design = await context.Designs.FirstOrDefaultAsync(design => design.Id == id, cancellationToken);
    return design is not null ? Results.Ok(design) 
                              : Results.NotFound();
}).WithName("getDesign");

app.MapPost("/createDesign", async (PixelArtContext context, GetDesignDTO getDesign, CancellationToken cancellationToken) => {
    var designType = await context.DesignTypes.FirstOrDefaultAsync(type => type.Id == getDesign.DesignTypeId, cancellationToken);
    var designPhotos = getDesign.DesignPhotos;
    if(designType == null) 
        return Results.NotFound("Invalid Design Type");
    else{
        var design = new Design();
        design.FillDesignFromGetDTO(getDesign, designType);
        await context.Designs.AddAsync(design, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Results.Created($"/getDesign/{design.Id}", design);
    }
}).WithName("createDesign");

app.MapPost("/UploadDesignMedia", async (IFormFile media) => {
    return Results.Ok("Okay");
}).Accepts<IFormFile>("multipart/form-data");

app.MapPut("/updateDesign", async (PixelArtContext context, GetDesignDTO getDesign) => {

});


app.Run();