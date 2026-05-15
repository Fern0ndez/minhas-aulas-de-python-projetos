// ==========================================================
// PROJETO: CONCESSIONÁRIA AUTOGESTÃO (BETA)
// TECNOLOGIA: C# WINDOWS FORMS
// STATUS: EM DESENVOLVIMENTO
// ==========================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AutoGestao
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Status { get; set; }
        public bool Danificado { get; set; }

        public override string ToString()
        {
            return $"{Modelo} - {Placa} ({Status})";
        }
    }

    // ==========================================================
    // MAIN FORM
    // ==========================================================

    public class MainForm : Form
    {
        private Panel menu;
        private Button btnEstoque;
        private Button btnOficina;
        private Button btnVendas;
        private Label lblTitulo;

        public static List<Veiculo> veiculos = new List<Veiculo>();

        public MainForm()
        {
            this.Text = "Concessionária AutoGestão - Gestão de Veículos";
            this.Size = new Size(1400, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            InicializarDados();
            InicializarInterface();
        }

        private void InicializarDados()
        {
            veiculos.Add(new Veiculo
            {
                Id = 1,
                Modelo = "Chevrolet Onix",
                Placa = "ABC1D23",
                Cor = "Vermelho",
                Ano = 2023,
                Status = "Pronto"
            });

            veiculos.Add(new Veiculo
            {
                Id = 2,
                Modelo = "Fiat Argo",
                Placa = "XYZ9A87",
                Cor = "Prata",
                Ano = 2022,
                Status = "Aguardando Revisão",
                Danificado = true
            });

            veiculos.Add(new Veiculo
            {
                Id = 3,
                Modelo = "HB20",
                Placa = "JKL2P90",
                Cor = "Branco",
                Ano = 2021,
                Status = "Em Manutenção"
            });
        }

        private void InicializarInterface()
        {
            menu = new Panel();
            menu.Size = new Size(220, this.Height);
            menu.BackColor = Color.FromArgb(10, 35, 66);
            menu.Dock = DockStyle.Left;
            this.Controls.Add(menu);

            lblTitulo = new Label();
            lblTitulo.Text = "AUTO\nGESTÃO";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitulo.Location = new Point(35, 40);
            lblTitulo.AutoSize = true;
            menu.Controls.Add(lblTitulo);

            btnEstoque = CriarBotao("Estoque", 200);
            btnEstoque.Click += BtnEstoque_Click;
            menu.Controls.Add(btnEstoque);

            btnOficina = CriarBotao("Oficina", 300);
            btnOficina.Click += BtnOficina_Click;
            menu.Controls.Add(btnOficina);

            btnVendas = CriarBotao("Vendas", 400);
            btnVendas.Click += BtnVendas_Click;
            menu.Controls.Add(btnVendas);

            Label beta = new Label();
            beta.Text = "Versão Beta 0.8";
            beta.ForeColor = Color.LightGray;
            beta.Location = new Point(35, 700);
            beta.AutoSize = true;
            menu.Controls.Add(beta);
        }

        private Button CriarBotao(string texto, int y)
        {
            Button btn = new Button();

            btn.Text = texto;
            btn.Size = new Size(180, 70);
            btn.Location = new Point(20, y);

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.BackColor = Color.FromArgb(20, 55, 95);
            btn.ForeColor = Color.White;

            btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            return btn;
        }

        private void BtnEstoque_Click(object sender, EventArgs e)
        {
            EstoqueForm form = new EstoqueForm();
            form.ShowDialog();
        }

        private void BtnOficina_Click(object sender, EventArgs e)
        {
            OficinaForm form = new OficinaForm();
            form.ShowDialog();
        }

        private void BtnVendas_Click(object sender, EventArgs e)
        {
            VendaForm form = new VendaForm();
            form.ShowDialog();
        }
    }

    // ==========================================================
    // ESTOQUE
    // ==========================================================

    public class EstoqueForm : Form
    {
        DataGridView grid = new DataGridView();

        public EstoqueForm()
        {
            this.Text = "Estoque";
            this.Size = new Size(1000, 600);

            grid.Dock = DockStyle.Fill;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowTemplate.Height = 35;

            grid.Columns.Add("Id", "ID");
            grid.Columns.Add("Modelo", "Modelo");
            grid.Columns.Add("Placa", "Placa");
            grid.Columns.Add("Cor", "Cor");
            grid.Columns.Add("Ano", "Ano");
            grid.Columns.Add("Status", "Status");

            foreach (var v in MainForm.veiculos)
            {
                int row = grid.Rows.Add(
                    v.Id,
                    v.Modelo,
                    v.Placa,
                    v.Cor,
                    v.Ano,
                    v.Status
                );

                if (v.Status == "Pronto")
                {
                    grid.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (v.Danificado)
                {
                    grid.Rows[row].DefaultCellStyle.BackColor = Color.IndianRed;
                }
                else
                {
                    grid.Rows[row].DefaultCellStyle.BackColor = Color.Khaki;
                }
            }

            this.Controls.Add(grid);
        }
    }

    // ==========================================================
    // OFICINA
    // ==========================================================

    public class OficinaForm : Form
    {
        ListBox lista;
        ComboBox mecanicos;

        public OficinaForm()
        {
            this.Text = "Ações de Manutenção - Oficina";
            this.Size = new Size(1200, 700);

            Label titulo = new Label();
            titulo.Text = "Veículos em Revisão";
            titulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            titulo.Location = new Point(30, 20);
            titulo.AutoSize = true;
            this.Controls.Add(titulo);

            lista = new ListBox();
            lista.Size = new Size(450, 450);
            lista.Location = new Point(30, 80);
            lista.Font = new Font("Segoe UI", 14);

            foreach (var v in MainForm.veiculos)
            {
                if (v.Status != "Vendido")
                {
                    lista.Items.Add(v.ToString());
                }
            }

            this.Controls.Add(lista);

            GroupBox box = new GroupBox();
            box.Text = "Ações de Manutenção";
            box.Location = new Point(550, 80);
            box.Size = new Size(500, 250);

            CheckBox c1 = new CheckBox();
            c1.Text = "Revisão Geral Preventiva";
            c1.Location = new Point(20, 40);

            CheckBox c2 = new CheckBox();
            c2.Text = "Reparo Suspensão";
            c2.Location = new Point(20, 80);

            CheckBox c3 = new CheckBox();
            c3.Text = "Pintura Para-Choque";
            c3.Location = new Point(20, 120);

            box.Controls.Add(c1);
            box.Controls.Add(c2);
            box.Controls.Add(c3);

            this.Controls.Add(box);

            Label mec = new Label();
            mec.Text = "Mecânico:";
            mec.Location = new Point(550, 360);
            mec.AutoSize = true;

            this.Controls.Add(mec);

            mecanicos = new ComboBox();
            mecanicos.Items.Add("João Silva");
            mecanicos.Items.Add("Carlos Souza");
            mecanicos.Items.Add("Pedro Henrique");

            mecanicos.Location = new Point(650, 355);
            mecanicos.Width = 250;

            this.Controls.Add(mecanicos);

            Button liberar = new Button();
            liberar.Text = "Marcar como Revisado e Liberar para Venda";
            liberar.Size = new Size(450, 90);
            liberar.Location = new Point(550, 420);

            liberar.BackColor = Color.Green;
            liberar.ForeColor = Color.White;
            liberar.Font = new Font("Segoe UI", 16, FontStyle.Bold);

            liberar.Click += Liberar_Click;

            this.Controls.Add(liberar);

            Button danificado = new Button();
            danificado.Text = "Marcar como Danificado";
            danificado.Size = new Size(450, 50);
            danificado.Location = new Point(550, 530);

            danificado.BackColor = Color.DarkRed;
            danificado.ForeColor = Color.White;

            danificado.Click += Danificado_Click;

            this.Controls.Add(danificado);
        }

        private void Liberar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Veículo liberado para venda!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void Danificado_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Veículo enviado para reparo.",
                "Oficina",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }

    // ==========================================================
    // VENDAS
    // ==========================================================

    public class VendaForm : Form
    {
        ComboBox combo;
        TextBox txtNome;
        TextBox txtCPF;
        TextBox txtTelefone;

        public VendaForm()
        {
            this.Text = "Vendas";
            this.Size = new Size(1200, 650);

            Label titulo = new Label();
            titulo.Text = "Dados do Veículo Selecionado";
            titulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            titulo.Location = new Point(40, 20);
            titulo.AutoSize = true;

            this.Controls.Add(titulo);

            combo = new ComboBox();
            combo.Location = new Point(50, 100);
            combo.Size = new Size(500, 40);
            combo.Font = new Font("Segoe UI", 14);

            foreach (var v in MainForm.veiculos)
            {
                if (v.Status == "Pronto")
                {
                    combo.Items.Add(v.ToString());
                }
            }

            this.Controls.Add(combo);

            GroupBox cliente = new GroupBox();
            cliente.Text = "Dados do Cliente Comprador";
            cliente.Location = new Point(650, 30);
            cliente.Size = new Size(450, 300);

            Label n = new Label();
            n.Text = "Nome:";
            n.Location = new Point(30, 50);

            txtNome = new TextBox();
            txtNome.Location = new Point(130, 50);
            txtNome.Width = 250;

            Label c = new Label();
            c.Text = "CPF:";
            c.Location = new Point(30, 110);

            txtCPF = new TextBox();
            txtCPF.Location = new Point(130, 110);
            txtCPF.Width = 250;

            Label t = new Label();
            t.Text = "Telefone:";
            t.Location = new Point(30, 170);

            txtTelefone = new TextBox();
            txtTelefone.Location = new Point(130, 170);
            txtTelefone.Width = 250;

            cliente.Controls.Add(n);
            cliente.Controls.Add(txtNome);
            cliente.Controls.Add(c);
            cliente.Controls.Add(txtCPF);
            cliente.Controls.Add(t);
            cliente.Controls.Add(txtTelefone);

            this.Controls.Add(cliente);

            Button finalizar = new Button();
            finalizar.Text = "FINALIZAR VENDA";
            finalizar.Size = new Size(400, 100);
            finalizar.Location = new Point(650, 380);

            finalizar.BackColor = Color.RoyalBlue;
            finalizar.ForeColor = Color.White;

            finalizar.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            finalizar.Click += Finalizar_Click;

            this.Controls.Add(finalizar);
        }

        private void Finalizar_Click(object sender, EventArgs e)
        {
            Form confirmacao = new Form();

            confirmacao.Text = "Confirmação de Venda";
            confirmacao.Size = new Size(700, 450);

            Label texto = new Label();

            texto.Text =
                "CONFIRMAÇÃO DE VENDA E SAÍDA DO VEÍCULO\n\n" +
                "Veículo: " + combo.Text + "\n\n" +
                "Cliente: " + txtNome.Text + "\n\n" +
                "Data: " + DateTime.Now.ToString("dd/MM/yyyy");

            texto.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            texto.Location = new Point(40, 40);
            texto.AutoSize = true;

            confirmacao.Controls.Add(texto);

            Button confirmar = new Button();

            confirmar.Text = "CONFIRMAR SAÍDA";
            confirmar.Size = new Size(350, 80);
            confirmar.Location = new Point(40, 250);

            confirmar.BackColor = Color.Green;
            confirmar.ForeColor = Color.White;

            confirmar.Click += (s, ev) =>
            {
                MessageBox.Show(
                    "Venda concluída!\nVeículo removido do estoque.",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                confirmacao.Close();
            };

            confirmacao.Controls.Add(confirmar);

            confirmacao.ShowDialog();
        }
    }

    // ==========================================================
    // PROGRAM
    // ==========================================================

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}