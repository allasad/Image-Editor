using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace Image_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.AutoScroll = true;
        }

        Image file;
        Boolean openeFile=false;
        
        void openImage() {
            DialogResult dlResult = openFileDialog1.ShowDialog();
            if (dlResult == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
                openeFile = true;
            }
        }

        #region rgb scale
        void rgbScale()
        {
            float changered = redbar.Value * 0.1f;
            float changegreen = greenbar.Value * 0.1f;
            float changeblue = bluebar.Value * 0.1f;

            redvalue.Text = changered.ToString();
            greenvalue.Text = changegreen.ToString();
            bluevalue.Text = changeblue.ToString();

            reload();
            if (!openeFile)
            {
            }
            else
            {
                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);   
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();                
                ColorMatrix colorPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+changered, 0, 0, 0, 0},
                    new float[]{0, 1+changegreen, 0, 0, 0},
                    new float[]{0, 0, 1+changeblue, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });

                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);          
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                           
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region save image
        void saveImage() {
            if (openeFile)
            {
                SaveFileDialog saveDialog = new SaveFileDialog(); 
                saveDialog.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string extension = Path.GetExtension(saveDialog.FileName);
                    switch (extension)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox1.Image.Save(saveDialog.FileName, format);
                }
            }
            else { MessageBox.Show("No image loaded, first upload image "); }
        }
        #endregion

        #region Gray Effect
        void gray()
        {
            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);   
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();                 
                ColorMatrix colorPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{0.299f, 0.299f, 0.299f, 0, 0},
                    new float[]{0.587f, 0.587f, 0.587f, 0, 0},
                    new float[]{0.114f, 0.114f, 0.114f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 0}
                });
                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);   
                                                           
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                            
                pictureBox1.Image = bitmapImg;
            }    
        }
        #endregion

        #region Afternoon Effect
        void afternoon()
        {

            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);   
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();                 
                ColorMatrix colorPicture = new ColorMatrix(new float[][]      
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0.7f, 0, 0, 0},
                    new float[]{0, 0, 1+1.3f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);  
                                                            

                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                            
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region Flash Effect
        void flash()
        {
            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image image = pictureBox1.Image;                            
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);   
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();                 
                ColorMatrix colorPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.9f, 0, 0, 0, 0},
                    new float[]{0, 1+1.5f, 0, 0, 0},
                    new float[]{0, 0, 1+1.3f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });

                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);  
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                           
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region Frozen Effect
        void Frozen()
        {

            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);  
                                                                       

                ImageAttributes imgAttributes = new ImageAttributes();               
                ColorMatrix colorPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0f, 0, 0, 0},
                    new float[]{0, 0, 1+5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });

                imgAttributes.SetColorMatrix(colorPicture);          
                Graphics graphics = Graphics.FromImage(bitmapImg);   
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                           
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region Sepia Effect
        void sepia()
        {
            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);  
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();                
                ColorMatrix colorPicture = new ColorMatrix(new float[][]     
                {
                    new float[]{.393f, .349f, .272f, 0, 0},
                    new float[]{.769f, .686f, .534f, 0, 0},
                    new float[]{.189f, .168f, .131f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });

                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);                                                              
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                            
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region Neon Effect
        void neon()
        {
            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);   
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();                 
                ColorMatrix colorPicture = new ColorMatrix(new float[][]        
                {
                    new float[]{.393f, .349f, .272f+1.3f, 0, 0},
                    new float[]{.769f, .686f+0.5f, .534f, 0, 0},
                    new float[]{.189f+2.3f, .168f, .131f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);  
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                           
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region Sunlight Effect
        void sunlight()
        {
            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);    
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();               
                ColorMatrix colorPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f, .349f+0.5f, .272f, 0, 0},
                    new float[]{.769f+0.3f, .686f, .534f, 0, 0},
                    new float[]{.189f, .168f, .131f+0.5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);                                                              
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                            
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region Dramatic Effect
        void dramatic()
        {
            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);   
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();                 
                ColorMatrix colorPicture = new ColorMatrix(new float[][]        
                {
                    new float[]{.393f+0.3f, .349f, .272f, 0, 0},
                    new float[]{.769f, .686f+0.2f, .534f, 0, 0},
                    new float[]{.189f, .168f, .131f+0.9f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);                                                             
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                            
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region Artistic Effect
        void artistic()
        {
            if (!openeFile)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image image = pictureBox1.Image;                             
                Bitmap bitmapImg = new Bitmap(image.Width, image.Height);   
                                                                        

                ImageAttributes imgAttributes = new ImageAttributes();                 
                ColorMatrix colorPicture = new ColorMatrix(new float[][]        
                {
                    new float[]{1,0,0,0,0},
                    new float[]{0,1,0,0,0},
                    new float[]{0,0,1,0,0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 1, 0, 1}
                });
                imgAttributes.SetColorMatrix(colorPicture);           
                Graphics graphics = Graphics.FromImage(bitmapImg);                                                               
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttributes);
                graphics.Dispose();                            
                pictureBox1.Image = bitmapImg;
            }
        }
        #endregion

        #region Reload
        void reload()
        {
            if (!openeFile)
            {
               
            }
            else
            {
                if (openeFile)
                {
                    file = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = file;
                    openeFile = true;
                }
            }
        }
        #endregion


     

        

        private void afternoonButton_Click_1(object sender, EventArgs e)
        {
            reload();
            afternoon();
        }

        private void grayButton_Click_1(object sender, EventArgs e)
        {
            reload();
            gray();
        }

        private void artisticButton_Click_1(object sender, EventArgs e)
        {
            reload();
            artistic();
        }

        private void sepiaButton_Click_1(object sender, EventArgs e)
        {
            reload();
            sepia();
        }

        private void noneButton_Click_1(object sender, EventArgs e)
        {
            greenbar.Value = 0;
            redbar.Value = 0;
            bluebar.Value = 0;
            greenvalue.Text = "0";
            redvalue.Text = "0";
            bluevalue.Text = "0";
            reload();
        }

        private void openButton_Click_1(object sender, EventArgs e)
        {
            openImage();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void flashButton_Click(object sender, EventArgs e)
        {
            reload();
            flash();
        }

        private void frozenButton_Click(object sender, EventArgs e)
        {
            reload();
            Frozen();
        }

        private void sunlightButton_Click_1(object sender, EventArgs e)
        {
            reload();
            sunlight();
        }

        private void dramaticButton_Click(object sender, EventArgs e)
        {
            reload();
            dramatic();
        }

        private void neonButton_Click(object sender, EventArgs e)
        {
            reload();
            neon();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void bluebar_ValueChanged(object sender, EventArgs e)
        {
            rgbScale();
        }

        private void redbar_Scroll(object sender, EventArgs e)
        {
            rgbScale();
        }

        private void redbar_ValueChanged(object sender, EventArgs e)
        {
            rgbScale();
        }

        private void greenbar_Scroll(object sender, EventArgs e)
        {
            rgbScale();
        }

        private void greenbar_ValueChanged(object sender, EventArgs e)
        {
            rgbScale();
        }

        private void bluebar_Scroll(object sender, EventArgs e)
        {
            rgbScale();
        }
    }
}
