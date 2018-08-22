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
            _document = new Document(PageSize.LETTER, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.LETTER);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            
            _pdfTable.SetWidths(new float[] { 90f, 180f });
            _pdfTable.DefaultCell.Border = Rectangle.NO_BORDER;
           
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
            _fontStyle = FontFactory.GetFont("Arial", 11f, 1);
            _pdfPCell = new PdfPCell();
            string imageURL = System.Web.HttpContext.Current.Server.MapPath("../Images");
            Image jpg = Image.GetInstance(imageURL + "/logo-universidad-de-caldas.jpg");
            jpg.ScaleToFit(140f, 120f);
            jpg.SpacingBefore = 10f;
            jpg.SpacingAfter = 1f;
            jpg.Alignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.AddElement(jpg);
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);


            _fontStyle = FontFactory.GetFont("Arial", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("HOSPITAL VETERINARIO DIEGO VILLEGAS TORO" + "\n" + "\n" + "SECCIÓN CIRUGIA" + "\n"
              + "\n" + "\n" + "AUTORIZACIÓN PARA INTERVENCIÓN QUIRÚRGICA Y OTROS PROCEDIMIENTOS ESPECIALES  ", _fontStyle));

            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

        }

        private void ReportBody()
        {



            #region tablebody
            _pdfTable.SetWidths(new float[] { 135f, 135f });
            _fontStyle = FontFactory.GetFont("Arial", 12f, 1);

            

            _pdfPCell= new PdfPCell(new Phrase("PROPIETARIO: " +autorizaCirugia.historiaFK.mascota.propietarioFK.nombreCompleto + "\n \n" +
                "PACIENTE: "+autorizaCirugia.historiaFK.mascota.nombre + "\n \n" + "ESPECIE: "+autorizaCirugia.historiaFK.mascota.raza.especie.nombre + "   "
                + " RAZA: "+autorizaCirugia.historiaFK.mascota.raza.nombre +"   "
                +" SEXO: "+autorizaCirugia.historiaFK.mascota.sexo, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("HISTORIA CLÍNICA No: " + autorizaCirugia.historiaFK.id.ToString() + "\n \n"
                +"DIRECCIÓN: Cra 21 #63 - 17 " + "\n \n"
                + " EDAD: " + autorizaCirugia.historiaFK.mascota.edad + "   "
                + " TELEFONO: "+autorizaCirugia.historiaFK.mascota.propietarioFK.celular, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);

           


            _fontStyle = FontFactory.GetFont("Arial", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("\n\nCertifico que habiendo sido informado sobre la naturaleza y proposito de " +
                "la intervención quirúrgica o procedimiento (que requiere utilización de anestesia) y sobre las complicaciones " +
                "y riesgos que ella implica, autorizo al HOSPITAL VETERINARIO DIEGO VILLEGAS TORO, área de CIRUGIA " +
                "y a los profesionales que laboran en dicha sección, la intervención del paciente. \n\n" +
                "Por tanto, los exonero de cualquier responabilidad civil, en caso de complicaciones o fallecimiento del paciente" +
                ", bien sea a causa de la intervención o de la anestesia. \n\n" +
                "De la misma manera autorizo al cirujano a realizar las intervenciones que el considere necesarias. \n\n", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();



            _pdfPCell = new PdfPCell(new Phrase(" \n\nOBSERVACIONES", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(" \n\n"+autorizaCirugia.observaciones, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase(" \n\nAUTORIZA: " +
                autorizaCirugia.historiaFK.mascota.propietarioFK.nombreCompleto+
                "\n\nFIRMA:________________________________"+
                "\n\nTELEFONO: "+autorizaCirugia.historiaFK.mascota.propietarioFK.celular+
                "\n\nMÉDICO VETERINARIO: NOMBRE LOGIN"+
                "\n\nCÉDULA:_________________", _fontStyle));
            
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);



            _pdfPCell = new PdfPCell(new Phrase("CEDULA: " +
                autorizaCirugia.historiaFK.mascota.propietarioFK.cedula+"\n\nDE:________________"+
                "\n\nDIRECCIÓN: Cra 21 # 63 - 17"+
                "\n\nFIRMA:_______________", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);


            

            _pdfPCell = new PdfPCell(new Phrase(" \n\nManizales " + DateTime.Now.ToShortDateString()
            , _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.Border = Rectangle.NO_BORDER;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

            #endregion
        }




    }
}