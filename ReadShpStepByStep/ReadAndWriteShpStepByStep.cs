using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ReadShpStepByStep
{
    public partial class ReadAndWriteShpStepByStep : Form
    {
        private String TextFileName = "";
        private String TextFileName2 = "";
        private String SaveFileName = "";
        Int32 lastrecordNum;
        Int32 lastrecordNum2;
        public ReadAndWriteShpStepByStep()
        {
            InitializeComponent();
        }

        private void CheckFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShpFilePath.Text = dialog.FileName;
                TextFileName = ShpFilePath.Text;
            }
            dialog.Dispose();
        }

        private void WriteFileBtn_Click(object sender, EventArgs e)
        {
            Int32 fileCode;
            Int32 unUsed1;
            Int32 unUsed2;
            Int32 unUsed3;
            Int32 unUsed4;
            Int32 unUsed5;
            Int32 fileLength;
            Int32 fileVerion;
            Int32 shapeType;
            double xMin;
            double yMin;
            double xMax;
            double yMax;
            double zMin;
            double zMax;
            double mMin;
            double mMax;
            Int32 fileCode2;
            Int32 unUsed12;
            Int32 unUsed22;
            Int32 unUsed32;
            Int32 unUsed42;
            Int32 unUsed52;
            Int32 fileLength2;
            Int32 fileVerion2;
            Int32 shapeType2;
            double xMin2;
            double yMin2;
            double xMax2;
            double yMax2;
            double zMin2;
            double zMax2;
            double mMin2;
            double mMax2;
            double xMin3;
            double yMin3;
            double xMax3;
            double yMax3;
            double zMin3;
            double zMax3;
            double mMin3;
            double mMax3;
            Int32 recordNum2;
            Int32 recordLength2;
            Int32 recordNum;
            Int32 recordLength;
            byte[] recordContents;

            BinaryReader binaryReader = null;
            FileStream fileStream = null;
            BinaryReader binaryReader3 = null;
            FileStream fileStream3 = null;
            // 首先判断，文件是否已经存在
            if (!File.Exists(TextFileName))
            {
                // 如果文件不存在，那么提示无法读取！
                MessageBox.Show(TextFileName + "文件不存在！");
                return;
            }

            try
            {
                if (File.Exists(SaveFileName))
                {
                    File.Delete(SaveFileName);
                }
                FileStream fileStream2 = new FileStream(SaveFileName, FileMode.Create, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter(fileStream2);
                fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader = new BinaryReader(fileStream);
                fileStream3 = new FileStream(TextFileName2, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader3 = new BinaryReader(fileStream3);

                byte[] bytes = new byte[4];
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileCode = BitConverter.ToInt32(bytes, 0);

                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed1 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed2 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed3 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed4 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed5 = BitConverter.ToInt32(bytes, 0);

                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileLength = BitConverter.ToInt32(bytes, 0);


                fileVerion = binaryReader.ReadInt32();
                shapeType = binaryReader.ReadInt32();
                xMin = binaryReader.ReadDouble();
                yMin = binaryReader.ReadDouble();
                xMax = binaryReader.ReadDouble();
                yMax = binaryReader.ReadDouble();
                zMin = binaryReader.ReadDouble();
                zMax = binaryReader.ReadDouble();
                mMin = binaryReader.ReadDouble();
                mMax = binaryReader.ReadDouble();
               
                bytes = binaryReader3.ReadBytes(4);
                Array.Reverse(bytes);
                fileCode2 = BitConverter.ToInt32(bytes, 0);

                bytes = binaryReader3.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed12 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader3.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed22 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader3.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed32 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader3.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed42 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader3.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed52 = BitConverter.ToInt32(bytes, 0);

                bytes = binaryReader3.ReadBytes(4);
                Array.Reverse(bytes);
                fileLength2 = BitConverter.ToInt32(bytes, 0);
                fileVerion2 = binaryReader3.ReadInt32();
                shapeType2 = binaryReader3.ReadInt32();
                xMin2 = binaryReader3.ReadDouble();
                yMin2 = binaryReader3.ReadDouble();
                xMax2 = binaryReader3.ReadDouble();
                yMax2 = binaryReader3.ReadDouble();
                zMin2 = binaryReader3.ReadDouble();
                zMax2 = binaryReader3.ReadDouble();
                mMin2 = binaryReader3.ReadDouble();
                mMax2 = binaryReader3.ReadDouble();

                mMax3 = mMax > mMax2 ? mMax : mMax2;
                xMax3 = xMax > xMax2 ? xMax : xMax2;
                yMax3 = yMax > yMax2 ? yMax : yMax2;
                zMax3 = zMax > zMax2 ? zMax : zMax2;
                mMin3 = mMin < mMin2 ? mMin : mMin2;
                xMin3 = xMin < xMin2 ? xMin : xMin2;
                zMin3 = zMin < zMin2 ? zMin : zMin2;
                yMin3 = yMin < yMin2 ? yMin : yMin2;

                byte[] bytesWriteFile;
                bytesWriteFile = BitConverter.GetBytes(fileCode);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                bytesWriteFile = BitConverter.GetBytes(unUsed1);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                bytesWriteFile = BitConverter.GetBytes(unUsed2);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                bytesWriteFile = BitConverter.GetBytes(unUsed3);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                bytesWriteFile = BitConverter.GetBytes(unUsed4);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                bytesWriteFile = BitConverter.GetBytes(unUsed5);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                bytesWriteFile = BitConverter.GetBytes(fileLength + fileLength2);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                binaryWriter.Write(fileVerion);
                binaryWriter.Write(shapeType);
                binaryWriter.Write(xMin3);
                binaryWriter.Write(yMin3);
                binaryWriter.Write(xMax3);
                binaryWriter.Write(yMax3);
                binaryWriter.Write(zMin3);
                binaryWriter.Write(zMax3);
                binaryWriter.Write(mMin3);
                binaryWriter.Write(mMax3);
               
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNum = BitConverter.ToInt32(bytes, 0);
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength = BitConverter.ToInt32(bytes, 0);
                    recordContents = binaryReader.ReadBytes(recordLength * 2);

                    bytesWriteFile = BitConverter.GetBytes(recordNum);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    bytesWriteFile = BitConverter.GetBytes(recordLength);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    binaryWriter.Write(recordContents);
                    lastrecordNum2 = recordNum;
                }
                while (binaryReader3.BaseStream.Position < binaryReader3.BaseStream.Length)
                {
                    bytes = binaryReader3.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNum2 = BitConverter.ToInt32(bytes, 0) + lastrecordNum2;
                    bytes = binaryReader3.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength = BitConverter.ToInt32(bytes, 0);
                    recordContents = binaryReader3.ReadBytes(recordLength * 2);

                    bytesWriteFile = BitConverter.GetBytes(recordNum2);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    bytesWriteFile = BitConverter.GetBytes(recordLength);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    binaryWriter.Write(recordContents);
                }
                binaryReader.Close();
                fileStream.Close();
                binaryReader = null;
                fileStream = null;
                binaryReader3.Close();
                fileStream3.Close();
                binaryReader3 = null;
                fileStream3 = null;
                binaryWriter.Close();
                fileStream2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("在读取文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视关闭是否会发生错误了.
                    }
                }
            }
        }

        private void ReadShpBtn_Click(object sender, EventArgs e)
        {
            BinaryReader binaryReader = null;
            FileStream fileStream = null;
            // 首先判断，文件是否已经存在
            if (!File.Exists(TextFileName))
            {
                // 如果文件不存在，那么提示无法读取！
                MessageBox.Show(TextFileName + "文件不存在！");
                return;
            }
            try
            {
                fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader = new BinaryReader(fileStream);

                Int32 fileCode;
                Int32 unUsed1;
                Int32 unUsed2;
                Int32 unUsed3;
                Int32 unUsed4;
                Int32 unUsed5;
                Int32 fileLength;
                Int32 fileVerion;
                Int32 shapeType;
                double xMin;
                double yMin;
                double xMax;
                double yMax;
                double zMin;
                double zMax;
                double mMin;
                double mMax;
                Int32 recordNum;
                Int32 recordLength;
                byte[] recordContents;
                //头的读取
                byte[] bytes = new byte[4];
                fileCode = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed1 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed2 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed3 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed4 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed5 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                fileLength = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                fileVerion = binaryReader.ReadInt32();
                shapeType = binaryReader.ReadInt32();
                xMin = binaryReader.ReadDouble();
                yMin = binaryReader.ReadDouble();
                xMax = binaryReader.ReadDouble();
                yMax = binaryReader.ReadDouble();
                zMin = binaryReader.ReadDouble();
                zMax = binaryReader.ReadDouble();
                mMin = binaryReader.ReadDouble();
                mMax = binaryReader.ReadDouble();
                


                ShowShpContents.Text = "";
                ShowShpContents.Text = TextFileName + "文件中的内容如下：\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "fileCode:  " + fileCode + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "unUsed1:   " + unUsed1 + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "unUsed2:   " + unUsed2 + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "unUsed3:   " + unUsed3 + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "unUsed4:   " + unUsed4 + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "unUsed5:   " + unUsed5 + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "fileLength:" + fileLength + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "fileVerion:" + fileVerion + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "shapeType: " + shapeType + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "xMin:      " + xMin + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "yMin:      " + yMin + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "xMax:      " + xMax + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "yMax:      " + yMax + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "zMin:      " + zMin + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "zMax:      " + zMax + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "mMin:      " + mMin + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "mMax:      " + mMax + "\r\n";
                ShowShpContents.Text = ShowShpContents.Text + "文件中的记录为：\r\n";
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                   
                    recordNum = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                    recordLength = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes); ;
                    recordContents = binaryReader.ReadBytes(recordLength * 2);
                    ShowShpContents.Text = ShowShpContents.Text + "记录编号:          " + recordNum + "\r\n";
                    ShowShpContents.Text = ShowShpContents.Text + "该记录长度（字节）:" + recordLength * 2 + "\r\n";
                }

                binaryReader.Close();
                fileStream.Close();
                binaryReader = null;
                fileStream = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在读取文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视关闭是否会发生错误了.
                    }
                }
            }
        }

        private void SelectSavePathBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Shape Files|*.shp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveFilePath.Text = dialog.FileName;
                SaveFileName = SaveFilePath.Text;
            }
            dialog.Dispose();
        }

        private void SaveFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowShpContents_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShpFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
                TextFileName2 = textBox1.Text;
            }
            dialog.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryReader binaryReader = null;
            FileStream fileStream = null;
            // 首先判断，文件是否已经存在
            if (!File.Exists(TextFileName2))
            {
                // 如果文件不存在，那么提示无法读取！
                MessageBox.Show(TextFileName2 + "文件不存在！");
                return;
            }
            try
            {
                fileStream = new FileStream(TextFileName2, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader = new BinaryReader(fileStream);

                Int32 fileCode2;
                Int32 unUsed12;
                Int32 unUsed22;
                Int32 unUsed32;
                Int32 unUsed42;
                Int32 unUsed52;
                Int32 fileLength2;
                Int32 fileVerion2;
                Int32 shapeType2;
                double xMin2;
                double yMin2;
                double xMax2;
                double yMax2;
                double zMin2;
                double zMax2;
                double mMin2;
                double mMax2;
                Int32 recordNum2;
                Int32 recordLength2;
                byte[] recordContents;

                byte[] bytes = new byte[4];
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileCode2 = BitConverter.ToInt32(bytes, 0);

                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed12 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed22 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed32 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed42 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed52 = BitConverter.ToInt32(bytes, 0);

                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileLength2 = BitConverter.ToInt32(bytes, 0);


                fileVerion2 = binaryReader.ReadInt32();
                shapeType2 = binaryReader.ReadInt32();
                xMin2 = binaryReader.ReadDouble();
                yMin2 = binaryReader.ReadDouble();
                xMax2 = binaryReader.ReadDouble();
                yMax2 = binaryReader.ReadDouble();
                zMin2 = binaryReader.ReadDouble();
                zMax2 = binaryReader.ReadDouble();
                mMin2 = binaryReader.ReadDouble();
                mMax2 = binaryReader.ReadDouble();



                textBox2.Text = "";
                textBox2.Text = TextFileName2 + "文件中的内容如下：\r\n";
                textBox2.Text = textBox2.Text + "fileCode:  " + fileCode2 + "\r\n";
                textBox2.Text = textBox2.Text + "unUsed1:   " + unUsed12 + "\r\n";
                textBox2.Text = textBox2.Text + "unUsed2:   " + unUsed22 + "\r\n";
                textBox2.Text = textBox2.Text + "unUsed3:   " + unUsed32 + "\r\n";
                textBox2.Text = textBox2.Text + "unUsed4:   " + unUsed42 + "\r\n";
                textBox2.Text = textBox2.Text + "unUsed5:   " + unUsed52 + "\r\n";
                textBox2.Text = textBox2.Text + "fileLength:" + fileLength2 + "\r\n";
                textBox2.Text = textBox2.Text + "fileVerion:" + fileVerion2 + "\r\n";
                textBox2.Text = textBox2.Text + "shapeType: " + shapeType2 + "\r\n";
                textBox2.Text = textBox2.Text + "xMin:      " + xMin2 + "\r\n";
                textBox2.Text = textBox2.Text + "yMin:      " + yMin2 + "\r\n";
                textBox2.Text = textBox2.Text + "xMax:      " + xMax2 + "\r\n";
                textBox2.Text = textBox2.Text + "yMax:      " + yMax2 + "\r\n";
                textBox2.Text = textBox2.Text + "zMin:      " + zMin2 + "\r\n";
                textBox2.Text = textBox2.Text + "zMax:      " + zMax2 + "\r\n";
                textBox2.Text = textBox2.Text + "mMin:      " + mMin2 + "\r\n";
                textBox2.Text = textBox2.Text + "mMax:      " + mMax2 + "\r\n";
                textBox2.Text = textBox2.Text + "文件中的记录为：\r\n";
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNum2 = BitConverter.ToInt32(bytes, 0);
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength2 = BitConverter.ToInt32(bytes, 0);
                    recordContents = binaryReader.ReadBytes(recordLength2 * 2);
                    textBox2.Text = textBox2.Text + "记录编号:          " + recordNum2 + "\r\n";
                    textBox2.Text = textBox2.Text + "该记录长度（字节）:" + recordLength2 * 2 + "\r\n";
                }

                binaryReader.Close();
                fileStream.Close();
                binaryReader = null;
                fileStream = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在读取文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视关闭是否会发生错误了.
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BinaryReader binaryReader = null;
            FileStream fileStream = null;
            BinaryReader binaryReader2 = null;
            FileStream fileStream2 = null;
            // 首先判断，文件是否已经存在
            if (!File.Exists(TextFileName))
            {
                // 如果文件不存在，那么提示无法读取！
                MessageBox.Show(TextFileName + "文件不存在！");
                return;
            }
            try
            {
                fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader = new BinaryReader(fileStream);

                Int32 fileCode;
                Int32 unUsed1;
                Int32 unUsed2;
                Int32 unUsed3;
                Int32 unUsed4;
                Int32 unUsed5;
                Int32 fileLength;
                Int32 fileVerion;
                Int32 shapeType;
                double xMin;
                double yMin;
                double xMax;
                double yMax;
                double zMin;
                double zMax;
                double mMin;
                double mMax;
                Int32 fileCode2;
                Int32 unUsed12;
                Int32 unUsed22;
                Int32 unUsed32;
                Int32 unUsed42;
                Int32 unUsed52;
                Int32 fileLength2;
                Int32 fileVerion2;
                Int32 shapeType2;
                double xMin2;
                double yMin2;
                double xMax2;
                double yMax2;
                double zMin2;
                double zMax2;
                double mMin2;
                double mMax2;
                double xMin3;
                double yMin3;
                double xMax3;
                double yMax3;
                double zMin3;
                double zMax3;
                double mMin3;
                double mMax3;
                Int32 recordNum2;
                Int32 recordLength2;
                Int32 recordNum;
                Int32 recordLength;
                byte[] recordContents;

                byte[] bytes = new byte[4];
                fileCode = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed1 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed2 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed3 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed4 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                unUsed5 = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);
                fileLength = ReadAndWriteShp.ReadShp_Big(binaryReader, bytes);


                fileVerion = binaryReader.ReadInt32();
                shapeType = binaryReader.ReadInt32();
                xMin = binaryReader.ReadDouble();
                yMin = binaryReader.ReadDouble();
                xMax = binaryReader.ReadDouble();
                yMax = binaryReader.ReadDouble();
                zMin = binaryReader.ReadDouble();
                zMax = binaryReader.ReadDouble();
                mMin = binaryReader.ReadDouble();
                mMax = binaryReader.ReadDouble();
                fileStream2 = new FileStream(TextFileName2, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader2 = new BinaryReader(fileStream2);

              
                bytes = binaryReader2.ReadBytes(4);
                Array.Reverse(bytes);
                fileCode2 = BitConverter.ToInt32(bytes, 0);

                bytes = binaryReader2.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed12 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader2.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed22 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader2.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed32 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader2.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed42 = BitConverter.ToInt32(bytes, 0);
                bytes = binaryReader2.ReadBytes(4);
                Array.Reverse(bytes);
                unUsed52 = BitConverter.ToInt32(bytes, 0);

                bytes = binaryReader2.ReadBytes(4);
                Array.Reverse(bytes);
                fileLength2 = BitConverter.ToInt32(bytes, 0);


                fileVerion2 = binaryReader2.ReadInt32();
                shapeType2 = binaryReader2.ReadInt32();
                xMin2 = binaryReader2.ReadDouble();
                yMin2 = binaryReader2.ReadDouble();
                xMax2 = binaryReader2.ReadDouble();
                yMax2 = binaryReader2.ReadDouble();
                zMin2 = binaryReader2.ReadDouble();
                zMax2 = binaryReader2.ReadDouble();
                mMin2 = binaryReader2.ReadDouble();
                mMax2 = binaryReader2.ReadDouble();

                mMax3 = mMax > mMax2 ? mMax : mMax2;
                xMax3 = xMax > xMax2 ? xMax : xMax2;
                yMax3 = yMax > yMax2 ? yMax : yMax2;
                zMax3 = zMax > zMax2 ? zMax : zMax2;
                mMin3 = mMin < mMin2 ? mMin : mMin2;
                xMin3 = xMin < xMin2 ? xMin : xMin2;
                zMin3 = zMin < zMin2 ? zMin : zMin2;
                yMin3 = yMin < yMin2 ? yMin : yMin2;

                textBox3.Text = "";
                textBox3.Text = TextFileName2 + "文件中的内容如下：\r\n";
                textBox3.Text = textBox3.Text + "fileCode:  " + fileCode + "\r\n";
                textBox3.Text = textBox3.Text + "unUsed1:   " + unUsed1 + "\r\n";
                textBox3.Text = textBox3.Text + "unUsed2:   " + unUsed2 + "\r\n";
                textBox3.Text = textBox3.Text + "unUsed3:   " + unUsed3 + "\r\n";
                textBox3.Text = textBox3.Text + "unUsed4:   " + unUsed4 + "\r\n";
                textBox3.Text = textBox3.Text + "unUsed5:   " + unUsed5 + "\r\n";
                textBox3.Text = textBox3.Text + "fileLength:" + (fileLength + fileLength2) + "\r\n";
                textBox3.Text = textBox3.Text + "fileVerion:" + fileVerion + "\r\n";
                textBox3.Text = textBox3.Text + "shapeType: " + shapeType + "\r\n";
                textBox3.Text = textBox3.Text + "xMin:      " + xMin3 + "\r\n";
                textBox3.Text = textBox3.Text + "yMin:      " + yMin3 + "\r\n";
                textBox3.Text = textBox3.Text + "xMax:      " + xMax3 + "\r\n";
                textBox3.Text = textBox3.Text + "yMax:      " + yMax3 + "\r\n";
                textBox3.Text = textBox3.Text + "zMin:      " + zMin3 + "\r\n";
                textBox3.Text = textBox3.Text + "zMax:      " + zMax3 + "\r\n";
                textBox3.Text = textBox3.Text + "mMin:      " + mMin3 + "\r\n";
                textBox3.Text = textBox3.Text + "mMax:      " + mMax3 + "\r\n";
                textBox3.Text = textBox3.Text + "文件中的记录为：\r\n";
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNum = BitConverter.ToInt32(bytes, 0);
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength = BitConverter.ToInt32(bytes, 0);
                    recordContents = binaryReader.ReadBytes(recordLength * 2);
                    textBox3.Text = textBox3.Text + "记录编号:          " + recordNum + "\r\n";
                    textBox3.Text = textBox3.Text + "该记录长度（字节）:" + recordLength * 2 + "\r\n";
                    lastrecordNum = recordNum;
                }
                binaryReader.Close();
                fileStream.Close();
                binaryReader = null;
                fileStream = null;
                while (binaryReader2.BaseStream.Position < binaryReader2.BaseStream.Length)
                {
                    bytes = binaryReader2.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNum2 = BitConverter.ToInt32(bytes, 0);
                    bytes = binaryReader2.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength2 = BitConverter.ToInt32(bytes, 0);
                    recordContents = binaryReader2.ReadBytes(recordLength2 * 2);
                    textBox3.Text = textBox3.Text + "记录编号:          " + (recordNum2 + lastrecordNum) + "\r\n";
                    textBox3.Text = textBox3.Text + "该记录长度（字节）:" + recordLength2 * 2 + "\r\n";
                }

                binaryReader2.Close();
                fileStream2.Close();
                binaryReader2 = null;
                fileStream2 = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在读取文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视关闭是否会发生错误了.
                    }
                }
            }
        }
    }
}
