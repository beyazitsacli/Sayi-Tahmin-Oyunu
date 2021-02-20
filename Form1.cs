using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _013_Sayi_Tahmin_Oyunu
{
    public partial class Form1 : Form
    {
        int sayi;
        int tahmin_sayisi = 0;
        int puan = 500;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;/*Baslangicta tahmin butonu olan button1 i devre disi birakıyoruz
                                     * cunku basla butonu ile kullanıcı tahmin yetkisine
                                     * sahip olacaktır.*/
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        button2.Enabled = false;/*Basla butonununa bastıgımızda bu butonun pasif edilemsi gerekir
                                     cunku oyuncu oyunu bitirmeden tekrardan
                                     basla butonuna basamamalıdır.*/
        button1.Enabled = true; /*Basla butonununa basıldıktan sonra oyunu istedigimiz zaman bitirebilmek için
                                     * tamam butonu aktif edilir.*/

            Random rnd = new Random(); /*rastgele sayi uretebilmek icin rnd isimli bir degisken turetiyoruz Random kutuphanesinden*/
            sayi = rnd.Next(1,100);/*Bu rnd den next komutu ile bir sayı ure e yazdırıyoruz */

            label8.Text = Convert.ToString(sayi);/* label8 e urettigimiz sayiyi string turunden yazdırıyoruz*/
            /*Normalde bu label8 i saklamamiz gerekiyor.Gormemiz gerekiyor
             * cunku biz bu sayiyi tahmin etmeye calisiyoruz*/

            label8.Visible = false;/*random secilen sayiyi gizler*/
                                                                                 
                                                   
            label5.Text = "-";
            label6.Text = "0";
            label7.Text = "500";




        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tahmin = 0;
            tahmin_sayisi = tahmin_sayisi + 1;

            if (tahmin_sayisi<=5)          
            {
                tahmin = int.Parse(textBox1.Text);/*Parse metodu, string türündeki bir veriyi, belirtilen 
                                                   * bir veri türüne dönüştürmede kullanılır.
                                                   * değişkenTürü.Parse(Dönüştürülecek Değer);
                                                   * ornek string sayi1="123"; olsun
                                                   * console.writeline(int32.Parse(sayi1));   
                                                   *satırı 123 sonucu verecek.
                                                    string sayi2=null; olsun 
                                                    console.writeline(int32.Parse(sayi2));   
                                                    sayi2 null olduğu için 
                                                    FormatException hatası alınır.
                                                    string sayi3="345.678";olsun
                                                    console.writeline(int32.Parse(sayi3));    
                                                    sayi3 değeri ondalıklı değer olduğu için 
                                                    int32 türünden farklıdır. FormatException hatası alınır.
                                                    string sayi4="12345678912349876762137817236782130";olsun
                                                    console.writeline(int32.Parse(sayi4)); 
                                                    sayi4 değeri int32 türünün sınırlarını aştığından 
                                                    OverflowException hatası alınır.*/



                label6.Text = tahmin_sayisi.ToString();
                if(sayi<tahmin)
                {
                    label5.Text = "Tahmininizi azaltiniz";
                    puan = puan - 100;
                    label7.Text = puan.ToString();

                }

                else if(sayi>tahmin)
                {
                    label5.Text = "Tahmininizi arttiriniz";
                    puan = puan - 100;
                    label7.Text = puan.ToString();
                }

                else
                {
                    label5.Text = "Tebrikler"+"  " +label6.Text+" " + "defada bilip,"+label7.Text+" puan aldiniz.";
                    button2.Enabled = true;
                    button1.Enabled = false;

                }
                textBox1.Text = "";


            }

            else
            {
                textBox1.Enabled = false;
                MessageBox.Show("Tahmin Hakkiniz Kalmadi! oyun kapatilacak");
                MessageBox.Show("secilen sayi"+" "+ label8.Text+"dir");
                this.Close();//formu kapatır
            }

        }
    }
}
