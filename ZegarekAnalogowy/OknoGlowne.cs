using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

////////////////////////////////////
///Zegar analogowy z tarczą 
///inspirowany zegarem z Win7
///Autor: Mariusz Doliński
////////////////////////////////////

namespace ZegarekAnalogowy
{
    public partial class OknoGlowne : Form
    {
        private Rectangle kwadrat;
        private LinearGradientBrush kolorObramowania;
        private SolidBrush kolorTarczy;
        private SolidBrush kolorLiczby;
        private SolidBrush kolorPodpisu;
        private Pen kolorCieniaTarczy;
        private Pen pioroGodzMin;
        private Pen pioroSek;
        private int srednica;

        static public string tekst = "";
        static public int zmianaCzasu = 0;

        private Point pozycjaMyszki, nowaPozMyszki, pozycjaOkna, nowaPozOkna;
        private bool czyMyszkaWcisnieta = false;

        public OknoGlowne()
        {
            InitializeComponent();
            inicjujNarzedzia();

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            
        }

        private void inicjujNarzedzia()
        {
            srednica = 120;
            kwadrat = new Rectangle(this.ClientSize.Width / 2 - srednica / 2, this.ClientSize.Height / 2 - srednica / 2, srednica, srednica);
            kolorObramowania = new LinearGradientBrush(kwadrat, Color.FromArgb(0, 0, 0), Color.FromArgb(60, 60, 60), 60);
            kolorTarczy = new SolidBrush(Color.WhiteSmoke);
            kolorLiczby = new SolidBrush(Color.FromArgb(10, 10, 10));
            kolorPodpisu = new SolidBrush(Color.Blue);
            kolorCieniaTarczy = new Pen(Color.FromArgb(180, 180, 180), 3);
            pioroGodzMin = new Pen(Color.FromArgb(10, 10, 10), 4);
            pioroSek = new Pen(Color.Red, 2);
            pioroGodzMin.EndCap = LineCap.ArrowAnchor;
            pioroSek.EndCap = LineCap.ArrowAnchor;
            pioroGodzMin.StartCap = LineCap.RoundAnchor;
            pioroSek.StartCap = LineCap.RoundAnchor;
            kolorCieniaTarczy.EndCap = LineCap.ArrowAnchor;
            kolorCieniaTarczy.StartCap = LineCap.RoundAnchor;
        }

        private void rysuj(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic; 

            int srodekWys = this.ClientSize.Height / 2;
            int srodekSzer = this.ClientSize.Width / 2;

            int minuty;
            int godziny;
            double sekundy;
            double minutyKat;
            double godzinyKat;
            double sekundyKat;

            float promien;
            int ramka = 18;
            int kat;

            DateTime czas;
            StringFormat format = new StringFormat();
            Font czcionka = new Font("Century", 12F, FontStyle.Bold);
            Font podpis = new Font("Century", 8F, FontStyle.Regular);


            //rysowanie tarczy
            g.FillEllipse(kolorObramowania, srodekSzer - srednica / 2 - ramka / 2, srodekWys - srednica / 2 - ramka / 2, srednica + ramka, srednica + ramka);
            g.FillEllipse(kolorTarczy, kwadrat);
            g.DrawEllipse(kolorCieniaTarczy, kwadrat);

            g.TranslateTransform(srodekSzer, srodekWys); // zmiana środka ukl. współrzednych

            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            if (tekst == "Polska") tekst = "";
            int dl = tekst.Length;
            if (dl != 0 && dl < 10 )
            {
                g.DrawString(tekst, podpis, kolorPodpisu, (-dl / 2) * 6, 15);
            }
            else if (dl != 0 && dl >= 10)
            {
                g.DrawString(tekst, podpis, kolorPodpisu, (-dl / 2) * 5, 15);
            }

            //rysowanie liczb
            promien = 49;
            kat = 360/12;
            for (int i = 1; i <= 12; i++)
            {
                g.DrawString(i.ToString(), czcionka, kolorLiczby, obliczX(i * kat - 90, promien) + 1, obliczY(i * kat - 90, promien) + 2, format);
            }

            //rysowanie ozdób
            promien = 61;
            for (int i = 0; i < 12; i++)
            {
                g.FillEllipse(kolorObramowania, obliczX(i * kat, promien) - 2, obliczY(i * kat, promien) - 2, 4, 4);
            }
            promien = 60;
            kat = 360 / 60;
            for (int i = 0; i < 60; i++)
            {
                g.FillEllipse(kolorObramowania, obliczX(i * kat, promien) - 1, obliczY(i * kat, promien) - 1, 2, 2);
            }

            //rysowanie wskazówek
            czas = DateTime.Now;
            godziny = czas.Hour + zmianaCzasu;
            minuty = czas.Minute;
            sekundy = czas.Second + (czas.Millisecond * 0.001);
            Point srodek = new Point(0, 0);

            //godziny
            promien = 39;
            godzinyKat = 2.0 * Math.PI * (godziny + minuty / 60.0) / 12.0;
            Point koniecCieniaGodz = new Point((int)(promien * Math.Sin(godzinyKat)) + 2, (int)((-promien) * Math.Cos(godzinyKat)) + 2);
            Point koniecWskGodz = new Point((int)(promien * Math.Sin(godzinyKat)), (int)((-promien) * Math.Cos(godzinyKat)));
            g.DrawLine(kolorCieniaTarczy, srodek, koniecCieniaGodz);
            g.DrawLine(pioroGodzMin, srodek, koniecWskGodz);

            //minuty
            promien = 57;
            minutyKat = 2.0 * Math.PI * (minuty + sekundy / 60.0) / 60.0;
            Point koniecCieniaMin = new Point((int)(promien * Math.Sin(minutyKat)) + 2, (int)((-promien) * Math.Cos(minutyKat)) + 2);
            Point koniecWskMin = new Point((int)(promien * Math.Sin(minutyKat)), (int)((-promien) * Math.Cos(minutyKat)));
            g.DrawLine(kolorCieniaTarczy, srodek, koniecCieniaMin);
            g.DrawLine(pioroGodzMin, srodek, koniecWskMin);

            //sekundy
            sekundyKat = 2.0 * Math.PI * sekundy / 60.0;
            Point koniecCieniaSek = new Point((int)(promien * Math.Sin(sekundyKat)) + 2, (int)((-promien) * Math.Cos(sekundyKat)) + 2);
            Point koniecWskSek = new Point((int)(promien * Math.Sin(sekundyKat)), (int)((-promien) * Math.Cos(sekundyKat)));
            g.DrawLine(kolorCieniaTarczy, srodek, koniecCieniaSek);
            g.DrawLine(pioroSek, srodek, koniecWskSek);

        }

        private float obliczX(float kat, float r)
        {
            return (float)(r * Math.Cos((Math.PI / 180) * kat));
        }

        private float obliczY(float kat, float r)
        {
            return (float)(r * Math.Sin((Math.PI / 180) * kat));
        }

        private void OknoGlowne_Paint(object sender, PaintEventArgs e)
        {
            rysuj(e.Graphics);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OknoGlowne_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip.Show(Control.MousePosition);
            }
        }

        private void OknoGlowne_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                czyMyszkaWcisnieta = true;
                pozycjaMyszki = Control.MousePosition;
                pozycjaOkna = Location;
            }
        }

        private void OknoGlowne_MouseMove(object sender, MouseEventArgs e)
        {
            if (czyMyszkaWcisnieta)
            {
                nowaPozMyszki = Control.MousePosition;
                nowaPozOkna.X = nowaPozMyszki.X - pozycjaMyszki.X + pozycjaOkna.X;
                nowaPozOkna.Y = nowaPozMyszki.Y - pozycjaMyszki.Y + pozycjaOkna.Y;
                Location = nowaPozOkna;
                pozycjaOkna = nowaPozOkna;
                pozycjaMyszki = nowaPozMyszki;
            }
        }

        private void OknoGlowne_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                czyMyszkaWcisnieta = false;
            }
        }

        private void wolnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            wolnoToolStripMenuItem.Checked = true;
            szybkoToolStripMenuItem.Checked = false;
        }

        private void szybkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 100;
            wolnoToolStripMenuItem.Checked = false;
            szybkoToolStripMenuItem.Checked = true;
        }

        private void kolorSekundnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog kolory = new ColorDialog();
            kolory.Color = pioroSek.Color;
            if (kolory.ShowDialog() == DialogResult.OK)
            {
                pioroSek.Color = kolory.Color;
            }            
        }

        private void czasNaSwiecieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CzasSwiatowy cs = new CzasSwiatowy();
            cs.Show();
        }
    }
}
