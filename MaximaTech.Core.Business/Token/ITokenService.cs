namespace MaximaTech.Core.Business.Token
{
    public interface ITokenService
    {
        string GenerateToken(string username, string role);
    }
}
