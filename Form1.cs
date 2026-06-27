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

        //BOTON AGREGAR
        private void button2_Click(object sender, EventArgs e)
        {
            E.M_EMPLEADO emple = new E.M_EMPLEADO();
            emple.nombre = this.textBox1.Text;
            emple.puesto = this.textBox2.Text;
            emple.edad = Convert.ToInt32(this.numericUpDown1.Value);
            emple.sueldo = Convert.ToDouble(this.numericUpDown2.Value); 

            string cadena = "workstation id=empresa2.mssql.somee.com;packet size=4096;user id=danielavf_SQLLogin_1;pwd=DaniEmpresa2026;data source=empresa2.mssql.somee.com;persist security info=False;initial catalog=empresa2;TrustServerCertificate=True";
            string sql = @"insert into
                EMPLEADOS(NOMBRE, EDAD, PUESTO, SUELDO)
                VALUES(@NOMBRE, @EDAD, @PUESTO, @SUELDO)";
            string sql2 = "select * from EMPLEADOS";


            using (var con = new Microsoft.Data.SqlClient.SqlConnection(cadena))
            {
                con.Open();
                con.Execute(sql, emple);
                this.dataGridView1.DataSource = con.Query<E.M_EMPLEADO>(sql2).ToList();
                con.Close();
            }
        }
    }

}

