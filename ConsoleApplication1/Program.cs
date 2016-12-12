using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string test = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2016_100.htm");
            StringBuilder output = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(new StringReader(test)))
            {
                //reader.ReadToFollowing("title"); // I guess name means friggin tag... 
                ////reader.MoveToFirstAttribute();
                //reader.MoveToContent();
                //string blah = reader.Value;
                //output.AppendLine("The genre value: " + blah);

                //reader.ReadToFollowing("title");
                reader.ReadToFollowing("p");
                reader.MoveToContent();
                output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString());
            }
            Console.WriteLine(output.ToString());
            Console.ReadLine();

            //StringBuilder output = new StringBuilder();

            //String xmlString =
            //            @"<bookstore>
            //    <book genre='autobiography' publicationdate='1981-03-22' ISBN='1-861003-11-0'>
            //        <title>The Autobiography of Benjamin Franklin</title>
            //        <author>
            //            <first-name>Benjamin</first-name>
            //            <last-name>Franklin</last-name>
            //        </author>
            //        <price>8.99</price>
            //    </book>
            //</bookstore>";

            //// Create an XmlReader
            //using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            //{
            //    reader.ReadToFollowing("book");
            //    reader.MoveToFirstAttribute();
            //    string genre = reader.Value;
            //    output.AppendLine("The genre value: " + genre);

            //    reader.ReadToFollowing("title");
            //    output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString()); // <--------------- this is it
            //}

            //Console.WriteLine(output.ToString());
            //Console.ReadLine();
        }
    }
}