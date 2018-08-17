using iTextSharp.text;
using iTextSharp.text.pdf;
using Software2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Software2.Reportes
{
    public class ReporteCirugia
    {
        #region Declaration
        int _totalColumn = 2;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(2);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        Auto_Cirugia autorizaCirugia = new Auto_Cirugia();
        #endregion 


        public byte[] PrepararReporte(Auto_Cirugia auto_Cirugia)
        {
            autorizaCirugia = auto_Cirugia;

            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 120f, 150f });
            #endregion

            this.ReportHeader();
            this.ReportBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();



        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);


            string imageURL = HttpContext.Current.Server.MapPath("C:/Users/anfer/Documents/GitHub/HospitalVeterinario/Software2/Images");
            Image jpg = Image.GetInstance(imageURL + "/logo-universidad-de-caldas.jpg");
            

            //Resize image depend upon your need

            jpg.ScaleToFit(140f, 120f);

            //Give space before image

            jpg.SpacingBefore = 10f;

            //Give some space after the image

            jpg.SpacingAfter = 1f;

            jpg.Alignment = Element.ALIGN_LEFT;
            _document.Add(jpg);

            _pdfPCell = new PdfPCell(new Phrase("AUTORIZACION DE CIRUGIA PARA MASCOTA", _fontStyle));
            _pdfPCell = new PdfPCell(new Phrase("La mascota "+autorizaCirugia.historiaFK.mascota.nombre +
                "se procede a autorizar una cirugia porque el perrito está enfermo entonces es mejor que el perrito sea operado, yo: " + autorizaCirugia.historiaFK.mascota.propietarioFK.nombreCompleto + " autorizo que el perrito sea operado", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(DateTime.Now.ToString(), _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }

        private void ReportBody()
        {
            #region Table Header
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            _pdfPCell = new PdfPCell(new Phrase("Id", _fontStyle));
            //_pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            


            _pdfPCell = new PdfPCell(new Phrase("Observaciones de la autorización", _fontStyle));
            //_pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
            #endregion


            #region tablebody
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);

            _pdfPCell = new PdfPCell(new Phrase(autorizaCirugia.historiaFK.id.ToString(), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase(autorizaCirugia.observaciones, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

            #endregion
        }




    }
}