using System;
using System.IO;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Menambahkan Watermark ke PDF");

        // Path file PDF input dan output
        string inputPdfPath = @"C:\Users\cleine\Downloads\CV_AdamFadrian_1";
        string outputPdfPath = "output.pdf";

        // Warna RGB merah (Red)
        Color merah = new DeviceRgb(255, 0, 0);

        // Teks yang akan digunakan sebagai watermark
        string watermarkText = "Watermark Saya";

        TambahkanWatermark(inputPdfPath, outputPdfPath, watermarkText, merah);

        Console.WriteLine("Watermark berhasil ditambahkan.");
    }

    static void TambahkanWatermark(string inputPdfPath, string outputPdfPath, string watermarkText, Color warnaTeks)
    {
        PdfDocument pdfDoc = new PdfDocument(new PdfReader(inputPdfPath), new PdfWriter(outputPdfPath));
        Document doc = new Document(pdfDoc);

        int jumlahHalaman = pdfDoc.GetNumberOfPages();

        for (int halaman = 1; halaman <= jumlahHalaman; halaman++)
        {
            doc.ShowTextAligned(new Paragraph(watermarkText).SetFontColor(warnaTeks).SetFontSize(40),
                pdfDoc.GetPage(halaman).GetPageSize().GetWidth() / 2,
                pdfDoc.GetPage(halaman).GetPageSize().GetHeight() / 2,
                halaman, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 45);
        }

        doc.Close();
    }
}

