// See https://aka.ms/new-console-template for more information

using ConsoleApp;

var security = new Security();

Console.WriteLine("Ingrese la contraseña a hashear:");
var key = Console.ReadLine();
var hashedPassword = security.HashString(key);
Console.WriteLine("Contraseña hasheada: " + hashedPassword);
Console.WriteLine("Ingrese nuevamente la contraseña, para verificarla:");
var keyToVerify = Console.ReadLine();
Console.WriteLine("Ingrese el hash para verificar contraseña:");
var hashToVerifie = Console.ReadLine();
var verified = security.VerifyKey(keyToVerify, hashToVerifie);
Console.WriteLine(verified);