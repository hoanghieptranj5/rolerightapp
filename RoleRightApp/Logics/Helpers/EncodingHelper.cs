namespace RoleRightApp.Logics.Helpers;

public static class EncodingHelper
{
    public static string EncodePasswordToBase64(string password)
    {
        try
        {
            var encDataByte = new byte[password.Length];
            encDataByte = System.Text.Encoding.UTF8.GetBytes(password);
            var encodedData = Convert.ToBase64String(encDataByte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while encoding..." + ex.Message);
        }
    }

    public static string DecodeFromBase64(string encodedData)
    {
        var encoder = new System.Text.UTF8Encoding();
        var utf8Decode = encoder.GetDecoder();
        var toDecodeByte = Convert.FromBase64String(encodedData);
        var charCount = utf8Decode.GetCharCount(toDecodeByte, 0, toDecodeByte.Length);
        var decodedChar = new char[charCount];
        utf8Decode.GetChars(toDecodeByte, 0, toDecodeByte.Length, decodedChar, 0);
        var result = new string(decodedChar);
        return result;
    }
}