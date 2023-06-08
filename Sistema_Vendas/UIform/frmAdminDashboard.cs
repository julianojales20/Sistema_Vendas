using Sistema_Vendas.UIform;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sistema_Vendas
{
    public partial class frmAdminDashboard : Form
    {
        private Dictionary<string, Form> formsAbertos; // Dicionário para armazenar os formulários abertos

        public frmAdminDashboard()
        {
            InitializeComponent();
            formsAbertos = new Dictionary<string, Form>(); // Inicializar o dicionário
        }

        private void AbrirFormulario(Form formulario, string nomeAba)
        {
            if (formsAbertos.ContainsKey(nomeAba))
            {
                // Se a aba já estiver aberta, trazê-la para frente
                tabControlPrincipal.SelectedTab = tabControlPrincipal.TabPages[nomeAba];
                return;
            }

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            TabPage novaAba = new TabPage(nomeAba);
            novaAba.Controls.Add(formulario);

            tabControlPrincipal.TabPages.Add(novaAba);
            formsAbertos.Add(nomeAba, formulario);

            formulario.Show();

            tabControlPrincipal.SelectedTab = novaAba;
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nomeAba = "Usuários";
            frmusers user = new frmusers();
            AbrirFormulario(user, nomeAba);
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nomeAba = "Categoria";
            FrmCategoria categoria = new FrmCategoria();
            AbrirFormulario(categoria, nomeAba);
        }

        private void frmAdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            frmlogin login = new frmlogin();
            login.Show();
        }
    }
}
