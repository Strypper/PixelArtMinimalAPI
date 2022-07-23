public class GetDesignDTO : BaseDTO{
    public string DesignName { get; set; }
    public int Likes { get; set; }
    public int Views { get; set; }
    public int DesignTypeId { get; set; }
    public string? Colors { get; set; }
    public DateTime DateUploaded { get; set; }
    public List<IFormFile> DesignPhotos { get; set; } = new List<IFormFile>();
}

public static class DesignExtensions{

    public static void FillDesignFromGetDTO(this Design design, GetDesignDTO dto, DesignType type){
        design.DesignName   = dto.DesignName;
        design.Likes        = dto.Likes;
        design.Views        = dto.Views;
        design.DesignType   = type;
        design.Colors       = dto.Colors;
        design.DateUploaded = dto.DateUploaded;
    }
}
