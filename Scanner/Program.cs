using System;
using System.Drawing.Printing;
using bpac;

class Program
{
    static void Main()
    {
        string fichier = @"C:\template.lbx";

        Document doc = new Document();

        if (!doc.Open(fichier))
        {
            Console.WriteLine("Erreur ouverture\n");
            return;
        }

        var barcode = doc.GetObject("BARCODE");
        if (barcode == null)
        {
            Console.WriteLine("Objet BARCODE introuvable\n");
            doc.Close();
            return;
        }

        barcode.Text = "SalutAdrien";

        bool exportOk = doc.Export(
            ExportType.bexBmp,
            @"D:\test.bmp",
            300
        );

        Console.WriteLine(exportOk ? "Image générée\n" : "Export échoué\n");

        Console.WriteLine("Imprimantes installées :");
        foreach (string printer in PrinterSettings.InstalledPrinters)
        {
            Console.WriteLine(printer);
        }

        //doc.SetPrinter("Brother PT-D600", true);
        doc.StartPrint("", PrintOptionConstants.bpoDefault);
        doc.PrintOut(1, PrintOptionConstants.bpoDefault);
        doc.EndPrint();

        doc.Close();

        Console.WriteLine("\nImpression envoyée !");

        Console.WriteLine("\nEnter to exit");
        Console.ReadLine();
    }
}