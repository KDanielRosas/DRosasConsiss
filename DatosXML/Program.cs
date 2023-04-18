using System;
using System.Security.Cryptography;
using System.Xml;

Console.WriteLine("\t----- Procesar archivo XML ----");
XmlDocument doc = new XmlDocument();
doc.Load("C:\\Users\\digis\\Documents\\Kevin Daniel Rosas Montoya\\datos.xml");
List<string> strings = new List<string>();
string tipo = "";
//Recorrer los elementos del archivo XML
foreach (XmlNode node in doc.DocumentElement.ChildNodes)
{
    tipo = node.Attributes["tipo"].Value;
    for (int i = 0; i < node.ChildNodes.Count; i++)
    {
        //Agregandos los valores a una lista de strings
        strings.Add(node.ChildNodes[i].InnerText);
    }
}

Console.WriteLine("<?xml version=\"1.0\" encoding=\"ISO-8859-1\">");
Console.WriteLine("<info>");
Console.WriteLine("\t<podcast tipo='" + tipo + "' libre='" + strings[0] + "' id='" + strings[1] + "' is3didfp='" + strings[7] +
    "' idaudio='" + strings[8] + "'>");
Console.WriteLine("\t\t<categoria>" + strings[2] + "</categoria>");
Console.WriteLine("\t\t<titulo>" + strings[3] + "</titulo>");
Console.WriteLine("\t\t<resumen>" + strings[4] + "</resumen>");
Console.WriteLine("\t\t<prevurl>" + strings[5] + "</prevurl>");
Console.WriteLine("\t\t<url>" + strings[6] + "</url>");
Console.WriteLine("\t</podcast>");
Console.WriteLine("</info>");

//Generar nuevo archivo XML
XmlDocument document = new XmlDocument();
XmlDeclaration xmlDeclaration = document.CreateXmlDeclaration("1.0", "ISO-8859-1", null);
XmlElement root = document.DocumentElement;
document.InsertBefore(xmlDeclaration, root);

XmlElement eInfo = document.CreateElement(string.Empty, "info", string.Empty);
document.AppendChild(eInfo);

XmlElement ePodcast = document.CreateElement(string.Empty, "podcast", string.Empty);
ePodcast.SetAttribute("tipo",tipo);
ePodcast.SetAttribute("libre", strings[0]);
ePodcast.SetAttribute("id", strings[1]);
ePodcast.SetAttribute("is3didfp", strings[7]);
ePodcast.SetAttribute("idaudio", strings[8]);
eInfo.AppendChild(ePodcast);

XmlElement eCategoria = document.CreateElement(string.Empty, "categoria", string.Empty);
XmlText categoria = document.CreateTextNode(strings[2]);
eCategoria.AppendChild(categoria);
ePodcast.AppendChild(eCategoria);

XmlElement eTitulo = document.CreateElement(string.Empty, "titulo", string.Empty);
XmlText titulo = document.CreateTextNode(strings[3]);
eTitulo.AppendChild(titulo);
ePodcast.AppendChild(eTitulo);

XmlElement eResumen = document.CreateElement(string.Empty, "resumen", string.Empty);
XmlText resumen = document.CreateTextNode(strings[4]);
eResumen.AppendChild(resumen);
ePodcast.AppendChild(eResumen);

XmlElement ePrevUrl = document.CreateElement(string.Empty, "prevurl", string.Empty);
XmlText prevUrl = document.CreateTextNode(strings[5]);
ePrevUrl.AppendChild(prevUrl);
ePodcast.AppendChild(ePrevUrl);

XmlElement eUrl = document.CreateElement(string.Empty, "url", string.Empty);
XmlText Url = document.CreateTextNode(strings[6]);
eUrl.AppendChild(Url);
ePodcast.AppendChild(eUrl);

document.Save("C:\\Users\\digis\\Documents\\Kevin Daniel Rosas Montoya\\archivoProcesado.xml");

Console.WriteLine("\nArchivo generado en: " +
    "C:\\Users\\digis\\Documents\\Kevin Daniel Rosas Montoya\\archivoProcesado.xml");
Console.ReadKey();