namespace BaseLibrary.Claims
{
    //the conext here is to check if the User has the neccesary authorization level, this can easily be passed to the Jwt for the front end if needed.
    public record CustomUserClaims(string Id = null!, string Name = null!, string Email = null!, string Role = null!);
}
