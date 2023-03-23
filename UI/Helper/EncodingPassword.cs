
namespace UI.Helper
{
    public class EncodingPassword
    {
        public static string EncodingPass(string pass)
        {
            string password = pass;
            byte[] source = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hash = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(source);
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                output.Append(hash[i].ToString("x2"));
            return output.ToString();
        }
    }
}

