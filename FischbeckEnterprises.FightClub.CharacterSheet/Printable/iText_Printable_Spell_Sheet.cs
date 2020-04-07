using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;
using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Forms;
using iText.Kernel.Font;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.IO.Font;
using iText.Layout.Properties;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Printable
{
    partial class PDFCreator
    {
        private void BuildSpellSheet()
        {
            string Spells_Sheet = $"{System.IO.Directory.GetCurrentDirectory()}\\Output\\Spells_Sheet.pdf";
            PdfWriter writer = new PdfWriter(Spells_Sheet);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.LETTER);
            document.SetMargins(20, 20, 20, 20);
            var font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            var bold = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            var table = new Table(new float[] { 1, 4, 1, 1, 1,1,6});
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Prepaired").SetFont(bold)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Name").SetFont(bold)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Casting").SetFont(bold)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Components").SetFont(bold)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Concentration").SetFont(bold)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Ritual").SetFont(bold)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Description").SetFont(bold)));
            for (int i = 0; i < 100; i++)
            {
                table.AddCell(new Cell().Add(new Paragraph("Prepaired")));
                table.AddCell(new Cell().Add(new Paragraph("Name")));
                table.AddCell(new Cell().Add(new Paragraph("Casting")));
                table.AddCell(new Cell().Add(new Paragraph("Components")));
                table.AddCell(new Cell().Add(new Paragraph("Concentration")));
                table.AddCell(new Cell().Add(new Paragraph("Ritual")));
                table.AddCell(new Cell().Add(new Paragraph("Description")));
            }
            document.Add(table);
            document.Close();
        }
    }
}
