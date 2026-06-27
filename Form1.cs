using Dapper;

namespace Tarea_3_Paradigmas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //BOTON CARGAR
        private void button3_Click(object sender, EventArgs e)
        {
            string cadena = "workstation id=empresa2.mssql.somee.com;packet size=4096;user id=danielavf_SQLLogin_1;pwd=DaniEmpresa2026;data source=empresa2.mssql.somee.com;persist security info=False;initial catalog=empresa2;TrustServerCertificate=True";
            string sql = "select * from EMPLEADOS";

            using (var con = new Microsoft.Data.SqlClient.SqlConnection(cadena))
            {
                this.dataGridView1.DataSource = con.Query<E.M_EMPLEADO>(sql).ToList();

            }
        }
    }

}

