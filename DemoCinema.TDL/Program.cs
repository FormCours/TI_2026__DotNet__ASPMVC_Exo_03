using DemoCinema.BLL.Helpers;

var helper = new HasherHelper();
string password = "Test1234=";

Console.WriteLine($"// 10 Hashs valides pour : {password}");
for (int i = 1; i <= 10; i++)
{
    string realHash = helper.Hash(password);
    Console.WriteLine($"{i}. {realHash}");
}
