using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Qiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string conexaoString = "server=localhost;user=root;password=;database=quiz;";

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            string pergunta = " ";
            string alternativaA = "", alternativaB = "",
                alternativaC = "", alternativaD = "";
            long ultimoID = 0;

            pergunta = rtxpergunta.Text;

            alternativaA = txbAlternativaA.Text;
            alternativaB = txbAlternativaB.Text;
            alternativaC = txbAlternativaC.Text;
            alternativaD = txbAlternativaD.Text;


            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                conexao.Open();
               string scripInsert = "INSERT INTO perguntas(pergunta,Alternativa) VALUE (@questao,@alternativa)";


                using (MySqlCommand comando = new MySqlCommand(scripInsert, conexao))
                {
                    //substitui os parametros para os valores reais.
                    comando.Parameters.AddWithValue("@questao", pergunta);
                    comando.Parameters.AddWithValue("@questao", alternativaA);

                    comando.ExecuteNonQuery();

                    ultimoID = comando.LastInsertedId;
                    


                }

            }


            MessageBox.Show("Pergunta Cadastrada com Sucesso!!");


        }



    }
}
