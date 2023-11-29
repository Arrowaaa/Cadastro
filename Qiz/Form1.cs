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

        public void CadastrarAlternativas(String alternativa, long ID)
        {
            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                conexao.Open();
                string insert_alternativa = "INNSERT INTO Alternativa(perguntas,Alternativa,Alternativa2,Alternativa3,Alternativa4) VALUE (@Alternativas)";

                using (MySqlCommand comando = new MySqlCommand(insert_alternativa, conexao))
                {
                    comando.Parameters.AddWithValue("@Alternativa", alternativa);
                    comando.Parameters.AddWithValue("Alternativa2",ID);

                    comando.ExecuteNonQuery();
                }

            }
        }

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
                string scripInsert = "INSERT INTO perguntas(pergunta,Alternativa) VALUE (@questao,@alternativas)";


                using (MySqlCommand comando = new MySqlCommand(scripInsert, conexao))
                {
                    //substitui os parametros para os valores reais.
                    comando.Parameters.AddWithValue("@questao", pergunta);
                   


                    comando.ExecuteNonQuery();

                    ultimoID = comando.LastInsertedId;
                    


                }

            }
            CadastrarAlternativas(alternativaA, ultimoID);
            CadastrarAlternativas(alternativaB, ultimoID);
            CadastrarAlternativas(alternativaC, ultimoID);
            CadastrarAlternativas(alternativaD, ultimoID);

            MessageBox.Show("Pergunta Cadastrada com Sucesso!!");


        }



    }
}
