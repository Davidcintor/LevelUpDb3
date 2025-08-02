using LevelUpDb3.Desktop.Models.Entities;

namespace LevelUpDb3.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new Models.ApplicationDbContext())
            {                 // Ensure the database is created
                context.Database.EnsureCreated();
                // Add a new client
                var cliente = new Models.Entities.Cliente
                {
                    Nombre = "John Doe",
                    Codigo = "12345"
                };
                context.Clientes.Add(cliente);
                context.SaveChanges();
                MessageBox.Show("Cliente agregado exitosamente.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new Models.ApplicationDbContext())
            {
                var productoCafe = new Producto
                {
                    Codigo = "Cafe",
                    Descripcion = "Cafe soluble dolca",
                    ValorUnitario = 50.00m,
                    FechaCreacion = DateTime.Now,
                };

                context.Add(productoCafe);
                context.SaveChanges();
            }       
        }
    }
}
