using Dapper;

namespace Tarea_3_Paradigmas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //BOTON MOSTRAR
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

                //nota para mi: estos limpian los campos
                this.textBox1.Clear();
                this.numericUpDown1.Value = 0;
                this.textBox2.Clear();
                this.numericUpDown2.Value = 0;


            }
        }

        //BOTON ELIMINAR
        private void button1_Click(object sender, EventArgs e)
        {
            //nota para mi: elimina la row entera, no un dato en especifico por ahora
            int r = this.dataGridView1.CurrentRow.Index;
            E.M_EMPLEADO p = new E.M_EMPLEADO();
            p.id = Convert.ToInt32(this.dataGridView1.Rows[r].Cells[0].Value.ToString());

            string cadena = "workstation id=empresa2.mssql.somee.com;packet size=4096;user id=danielavf_SQLLogin_1;pwd=DaniEmpresa2026;data source=empresa2.mssql.somee.com;persist security info=False;initial catalog=empresa2;TrustServerCertificate=True";
            string sql_b = @"
                           delete from EMPLEADOS
                           where id=@id";

            string sql = "select * from EMPLEADOS";
            using (var con = new Microsoft.Data.SqlClient.SqlConnection(cadena))
            {
                con.Execute(sql_b, p);
                this.dataGridView1.DataSource = con.Query<E.M_EMPLEADO>(sql).ToList();
            }
        }
    }

}

