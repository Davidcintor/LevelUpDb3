using LevelUpDb3.Desktop.Models.Dtos;
using LevelUpDb3.Desktop.Models.Entities;

namespace LevelUpDb3.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Replace 'VentaJsonDto' with 'VentaImportDto' to match the signature of LecturaArchivoJSON.LeerArchivo
            try
            {
                string rutaArchivo = @"C:\Users\david\source\repos\LevelUpDb3\LevelUpDb3.Desktop\ArchivosFake\ventas_fake.json";
                List<VentaImportDto> ventas =
                    new LecturaArchivoJSON().LeerArchivo(rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnImportarJson_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaArchivo = @"C:\Users\david\source\repos\LevelUpDb3\LevelUpDb3.Desktop\ArchivosFake\ventas_fake.json";
                var ventas = new LecturaArchivoJSON().LeerArchivo(rutaArchivo);
                await new ImportadorVentasService().ImportarVentasAsync(ventas);
                MessageBox.Show("Los datos del archivo JSON se importaron correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar JSON: " + ex.Message);
            }
        }

        private async void btnImportarTxt_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaArchivo = @"C:\Users\david\source\repos\LevelUpDb3\LevelUpDb3.Desktop\ArchivosFake\ventas_fake.txt";
                var ventas = new LecturaArchivoTXT().LeerArchivo(rutaArchivo);
                await new ImportadorVentasService().ImportarVentasAsync(ventas);
                MessageBox.Show("Importación de TXT completada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar TXT: " + ex.Message);
            }
        }

        private async void btnImportarXml_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaArchivo = @"C:\Users\david\source\repos\LevelUpDb3\LevelUpDb3.Desktop\ArchivosFake\ventas_fake.xml";
                var ventas = new LecturaArchivoXML().LeerArchivo(rutaArchivo);
                await new ImportadorVentasService().ImportarVentasAsync(ventas);
                MessageBox.Show("Importación de XML completada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar XML: " + ex.Message);
            }
        }

        private void btnImportarJson_Click_1(object sender, EventArgs e)
        {

        }
    }
}
