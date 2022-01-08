using System.Drawing;
using System.Drawing.Drawing2D;

namespace NassiBlocks
{

    /// <summary>
    /// Drawing options
    /// (Параметры отрисовки)
    /// </summary>
    public struct Parametrs
    {
        /// <summary>
        /// The font of the text in the block
        /// (Шрифт текста в блоке)
        /// </summary>
        public Font font;
        /// <summary>
        /// Format of text output in a block
        /// (Формат вывода текста в блоке)
        /// </summary>
        public StringFormat drawFormat;
    }


    /// <summary>
    /// Block drawing
    /// (Рисование блока)
    /// </summary>
    public class DrawBlock
    {
        #region Init
        /// <summary>
        /// Drawn block
        /// (Отрисованный блок)
        /// </summary>
        public static Bitmap Block = new Bitmap(52, 28);

        /// <summary>
        /// Graphics
        /// (Графика)
        /// </summary>
        private Graphics graf = Graphics.FromImage(Block);

        /// <summary>
        /// Parametrs
        /// (Параметры)
        /// </summary>
        private Parametrs parametrs = new Parametrs();


        /// <summary>
        /// Constructor
        /// Конструктор
        /// </summary>
        public DrawBlock()
        {
            parametrs.font = new Font(FontFamily.GenericSerif, 8, FontStyle.Regular);
            parametrs.drawFormat = new StringFormat() { Alignment = StringAlignment.Center };
        }


        /// <summary>
        /// Constructor with font
        /// Конструктор с указанием шрифта
        /// </summary>
        /// <param name="font">Шрифт (Font)</param>
        public DrawBlock(Font font)
        {
            parametrs.font = font;
            parametrs.drawFormat = new StringFormat() { Alignment = StringAlignment.Center };
        }

        /// <summary>
        /// Constructor with Drawing Format
        /// Конструктор с указанием формата
        /// </summary>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        public DrawBlock(StringFormat drawFormat)
        {
            parametrs.font = new Font(FontFamily.GenericSerif, 8, FontStyle.Regular);
            parametrs.drawFormat = drawFormat;
        }


        /// <summary>
        /// Constructor with font, Drawing Format
        /// Конструктор с указанием шрифта, формата
        /// </summary>
        /// <param name="font">Шрифт (Font)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        public DrawBlock(Font font, StringFormat drawFormat)
        {
            parametrs.font = font;
            parametrs.drawFormat = drawFormat;
        }
        #endregion
        #region Params
        /// <summary>
        /// Changing parameters to standard
        /// (Изменение параметров на стандартные)
        /// </summary>
        public void SetParams()
        {
            parametrs.font = new Font(FontFamily.GenericSerif, 8, FontStyle.Regular);
            parametrs.drawFormat = new StringFormat();
        }


        /// <summary>
        /// Change text settings
        /// (Изменение параметров текста)
        /// </summary>
        /// <param name="font">Text parametrs (Параметры текста)</param>
        public void SetParams(Font font)
        {
            parametrs.font = font;
        }


        /// <summary>
        /// Changing Drawing Format Options
        /// (Изменение параметров формата отрисовки)
        /// </summary>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        public void SetParams(StringFormat drawFormat)
        {
            parametrs.drawFormat = drawFormat;
        }


        /// <summary>
        /// Changing Drawing Format and Text Format Options
        /// (Изменение параметров формата отрисовки и текста)
        /// </summary>
        /// <param name="font">Text parametrs (Параметры текста)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        public void SetParams(Font font, StringFormat drawFormat)
        {
            parametrs.font = font;
            parametrs.drawFormat = drawFormat;
        }
        #endregion
        #region Rectangle
        /// <summary>
        /// Drawing paths and fills for blocks
        /// (Рисование контура и заливки для блоков)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        private void DrawRectangle(Color color, Color contrColor, int width, int height)
        {
            Block = new Bitmap(width, height);
            graf = Graphics.FromImage(Block);
            graf.SmoothingMode = SmoothingMode.HighQuality;
            graf.FillRectangle(new SolidBrush(color), 1, 1, width - 1, height - 1);
            graf.DrawRectangle(new Pen(contrColor, 1), 0, 0, width - 1, height - 1);
        }
        #endregion
        #region OperationBlock
        /// <summary>
        /// Операционный блок 52х28px
        /// (Operation Block)
        /// </summary>
        /// <returns>Блок операции (Operation Block)</returns>
        public Bitmap OperationBlock()
        {
            DrawRectangle(Color.White, Color.Black, 52, 28);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Операционный блок с указанием высоты и ширины
        /// (Operation Block with indication of height and width)
        /// </summary>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <returns>Блок операции (Operation Block)</returns>
        public Bitmap OperationBlock(int width, int height)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Операционный блок с указанием высоты и ширины, текста
        /// (Operation Block with indication of height and width, text)
        /// </summary>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Блок операции (Operation Block)</returns>
        public Bitmap OperationBlock(int width, int height, string text)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Операционный блок с указанием высоты и ширины, текста, цвета блока
        /// (Operation Block with indication of height and width, text, block color)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Блок операции (Operation Block)</returns>
        public Bitmap OperationBlock(Color color, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Операционный блок с указанием высоты и ширины, текста, цвета блока, цвета текста
        /// (Operation Block with indication of height and width, text, block color, text color)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Блок операции (Operation Block)</returns>
        public Bitmap OperationBlock(Color color, Color fontColor, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Операционный блок с указанием высоты и ширины, текста, цвета блока, цвета текста, цвета контура
        /// (Operation Block with indication of height and width, text, block color, text color, outline color)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Блок операции (Operation Block)</returns>
        public Bitmap OperationBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Операционный блок с указанием высоты и ширины, текста, цвета блока, цвета текста, цвета контура, шрифта
        /// (Operation Block with indication of height and width, text, block color, text color, outline color, font)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <returns>Блок операции (Operation Block)</returns>
        public Bitmap OperationBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, Font font)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawString(text, font, new SolidBrush(fontColor), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }
        /// <summary>
        /// Операционный блок с указанием высоты и ширины, текста, цвета блока, цвета текста, цвета контура, шрифта, формата отрисовки
        /// (Operation Block with indication of height and width, text, block color, text color, outline color, font, drawing format)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        /// <returns>Блок операции (Operation Block)</returns>
        public Bitmap OperationBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, Font font, StringFormat drawFormat)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawString(text, font, new SolidBrush(fontColor), width / 2, height / 2 - parametrs.font.Size, drawFormat);
            graf.Dispose();
            return Block;
        }
        #endregion
        #region BranchingBlock
        /// <summary>
        /// Branching Block
        /// (Блок ветвления)
        /// </summary>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock()
        {
            DrawRectangle(Color.White, Color.Black, 52, 28);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(26, 14));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(26, 14), new Point(52, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 14), new Point(52, 14));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(26, 28), new Point(26, 14));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width
        /// (Блок ветвления c указанием высоты и ширины)
        /// </summary>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(int width, int height)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(width / 2, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 2, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 2, height), new Point(width / 2, height / 2));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text
        /// (Блок ветвления, текста)
        /// </summary>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(int width, int height, string text)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(width / 2, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 2, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 2, height), new Point(width / 2, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / 2, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text, block color
        /// (Блок ветвления, текста, цвета блока)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(Color color, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(width / 2, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 2, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 2, height), new Point(width / 2, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / 2, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text, block color, text color
        /// (Блок ветвления, текста, цвета блока, цвета текста)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(Color color, Color fontColor, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(width / 2, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 2, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 2, height), new Point(width / 2, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text, block color, text color, outline color
        /// (Блок ветвления, текста, цвета блока, цвета текста, цвет контура)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width / 2, height / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, height), new Point(width / 2, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text, block color, text color, outline color, added width
        /// (Блок ветвления, текста, цвета блока, цвета текста, цвет контура, добавленная высота)
        /// </summary>
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight)
        {
            DrawRectangle(color, contrColor, width, height + addHeight);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, height), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text, block color, text color, outline color, added width, Additional bool
        /// (Блок ветвления, текста, цвета блока, цвета текста, цвет контура, добавленная высота, добавление надписей)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="isAdditional">Добавление надписей да и нет (Add yes and no labels)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, bool isAdditional)
        {
            DrawRectangle(color, contrColor, width, height + addHeight);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, height), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, 0, parametrs.drawFormat);
            if (isAdditional)
            {
                graf.DrawString("Да", parametrs.font, new SolidBrush(fontColor), 0 + 2 * parametrs.font.Size, ((height - addHeight) / 6), parametrs.drawFormat);
                graf.DrawString("Нет", parametrs.font, new SolidBrush(fontColor), width - 2 * parametrs.font.Size, ((height - addHeight) / 6), parametrs.drawFormat);
            }
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text, block color, text color, outline color, added width, Additional bool
        /// (Блок ветвления, текста, цвета блока, цвета текста, цвет контура, добавленная высота, добавление надписей)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="isAdditional">Добавление надписей да и нет (Add yes and no labels)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, bool isAdditional, StringFormat drawFormat)
        {
            DrawRectangle(color, contrColor, width, height + addHeight);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, height), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, 0, drawFormat);
            if (isAdditional)
            {
                graf.DrawString("Да", parametrs.font, new SolidBrush(fontColor), 0 + 2 * parametrs.font.Size, ((height - addHeight) / 6), drawFormat);
                graf.DrawString("Нет", parametrs.font, new SolidBrush(fontColor), width - 2 * parametrs.font.Size, ((height - addHeight) / 6), drawFormat);
            }
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text, block color, text color, outline color, added width, Additional bool, font
        /// (Блок ветвления, текста, цвета блока, цвета текста, цвет контура, добавленная высота, добавление надписей, шрифта)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="isAdditional">Добавление надписей да и нет (Add yes and no labels)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, bool isAdditional, Font font)
        {
            DrawRectangle(color, contrColor, width, height + addHeight);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, height), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawString(text, font, new SolidBrush(fontColor), width / 2, 0, parametrs.drawFormat);
            if (isAdditional)
            {
                graf.DrawString("Да", font, new SolidBrush(fontColor), 0 + 2 * font.Size, ((height - addHeight) / 6), parametrs.drawFormat);
                graf.DrawString("Нет", font, new SolidBrush(fontColor), width - 2 * font.Size, ((height - addHeight) / 6), parametrs.drawFormat);
            }
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Branching Block with indication of height and width, text, block color, text color, outline color, added width, Additional bool, font, drawing format
        /// (Блок ветвления, текста, цвета блока, цвета текста, цвет контура, добавленная высота, добавление надписей, шрифта, формата отрисовки)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="isAdditional">Добавление надписей да и нет (Add yes and no labels)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        /// <returns>Branching Block (Блок ветвления)</returns>
        public Bitmap BranchingBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, bool isAdditional, Font font, StringFormat drawFormat)
        {
            DrawRectangle(color, contrColor, width, height + addHeight);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 2, height), new Point(width / 2, (height - addHeight) / 2));
            graf.DrawString(text, font, new SolidBrush(fontColor), width / 2, 0, drawFormat);
            if (isAdditional)
            {
                graf.DrawString("Да", font, new SolidBrush(fontColor), 0 + 2 * font.Size, ((height - addHeight) / 6), drawFormat);
                graf.DrawString("Нет", font, new SolidBrush(fontColor), width - 2 * font.Size, ((height - addHeight) / 6), drawFormat);
            }
            graf.Dispose();
            return Block;
        }
        #endregion
        #region CaseBlock
        /// <summary>
        /// Case Block
        /// (Кейс-блок)
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock()
        {
            DrawRectangle(Color.White, Color.Black, 52, 28);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(39, 14));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(39, 14), new Point(52, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 14), new Point(52, 14));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(39, 14), new Point(39, 28));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width
        /// (Кейс-блок с указанием высоты и ширины)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(int width, int height)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(width - width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, height / 2), new Point(width - width / 4, height));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width, text
        /// (Кейс-блок, с указанием высоты и ширины, текста)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(int width, int height, string text)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(width - width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, height / 2), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width - width / 3, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width, text, block color
        /// (Кейс-блок, с указанием высоты и ширины, текста, цвета блока)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(Color color, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(width - width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, height / 2), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width - width / 3, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width, text, block color, text color
        /// (Кейс-блок, с указанием высоты и ширины, текста, цвета блока, цвета текста)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(Color color, Color fontColor, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(width - width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, height / 2), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width - width / 3, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width, text, block color, text color, outline color
        /// (Кейс-блок, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width - width / 4, height / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, height / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, height / 2), new Point(width, height / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, height / 2), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width - width / 3, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width, text, block color, text color, outline color, added width
        /// (Кейс-блок, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура, добавленная высота)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width - width / 4, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, (height - addHeight) / 2), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width - width / 3, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width, text, block color, text color, outline color, added width, font
        /// (Кейс-блок, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура, добавленная высота, шрифта)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, Font font)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width - width / 4, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, (height - addHeight) / 2), new Point(width - width / 4, height));
            graf.DrawString(text, font, new SolidBrush(fontColor), width - width / 3, 0, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width, text, block color, text color, outline color, added width, drawing format
        /// (Кейс-блок, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура, добавленная высота, формата отрисовки)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, StringFormat drawFormat)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width - width / 4, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, (height - addHeight) / 2), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width - width / 3, 0, drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Case Block with indication of height and width, text, block color, text color, outline color, added width, font, drawing format
        /// (Кейс-блок, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура, добавленная высота, шрифта, формата отрисовки)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        /// <returns>Case Block (Кейс-блок)</returns>
        public Bitmap CaseBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, Font font, StringFormat drawFormat)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, 0), new Point(width - width / 4, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, (height - addHeight) / 2), new Point(width, 0));
            graf.DrawLine(new Pen(contrColor, 1), new Point(0, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, (height - addHeight) / 2), new Point(width - width / 4, height));
            graf.DrawString(text, font, new SolidBrush(fontColor), width - width / 3, 0, drawFormat);
            graf.Dispose();
            return Block;
        }
        #endregion
        #region PreconditionBlock
        /// <summary>
        /// Precondition block
        /// (Блок цикла с предусловием)
        /// <returns>Precondition Block (Блок цикла с предусловием)</returns>
        public Bitmap PreconditionBlock()
        {
            DrawRectangle(Color.White, Color.Black, 52, 28);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(13, 28), new Point(13, 14));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(13, 14), new Point(52, 14));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Precondition block with indication of height and width
        /// (Блок цикла с предусловием, с указанием высоты и ширины)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <returns>Precondition Block (Блок цикла с предусловием)</returns>
        public Bitmap PreconditionBlock(int width, int height)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Precondition block with indication of height and width, text
        /// (Блок цикла с предусловием, с указанием высоты и ширины, текста)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Precondition Block (Блок цикла с предусловием)</returns>
        public Bitmap PreconditionBlock(int width, int height, string text)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / (width / 2), height / (int)(height / 1.75));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Precondition block with indication of height and width, text, block color
        /// (Блок цикла с предусловием, с указанием высоты и ширины, текста, цвета блока)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Precondition Block (Блок цикла с предусловием)</returns>
        public Bitmap PreconditionBlock(Color color, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / (width / 2), height / (int)(height / 1.75));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Precondition block with indication of height and width, text, block color, text color
        /// (Блок цикла с предусловием, с указанием высоты и ширины, текста, цвета блока, цвета текста)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Precondition Block (Блок цикла с предусловием)</returns>
        public Bitmap PreconditionBlock(Color color, Color fontColor, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / (width / 2), height / (int)(height / 1.75));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Precondition block with indication of height and width, text, block color, text color, outline color
        /// (Блок цикла с предусловием, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Precondition Block (Блок цикла с предусловием)</returns>
        public Bitmap PreconditionBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, height), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / (width / 2), height / (int)(height / 1.75));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Precondition block with indication of height and width, text, block color, text color, outline color, added width
        /// (Блок цикла с предусловием, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура, добавленная высота)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <returns>Precondition Block (Блок цикла с предусловием)</returns>
        public Bitmap PreconditionBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight)
        {
            DrawRectangle(color, contrColor, width, height + addHeight);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, height), new Point(width / 4, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / (width / 2), height / (int)(height / 1.75));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Precondition block with indication of height and width, text, block color, text color, outline color, added width, font
        /// (Блок цикла с предусловием, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура, добавленная высота, шрифта)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <returns>Precondition Block (Блок цикла с предусловием)</returns>
        public Bitmap PreconditionBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, Font font)
        {
            DrawRectangle(color, contrColor, width, height + addHeight);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, height), new Point(width / 4, (height - addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, (height - addHeight) / 2), new Point(width, (height - addHeight) / 2));
            graf.DrawString(text, font, new SolidBrush(fontColor), width / (width / 2), height / (int)(height / 1.75));
            graf.Dispose();
            return Block;
        }
        #endregion
        #region PostconditionBlock
        /// <summary>
        /// Postcondition block
        /// (Блок цикла с постусловием)
        /// <returns>Precondition Block (Блок цикла с постусловием)</returns>
        public Bitmap PostconditionBlock()
        {
            DrawRectangle(Color.White, Color.Black, 52, 28);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(13, 0), new Point(13, 14));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(13, 14), new Point(52, 14));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Postcondition block with indication of height and width
        /// (Блок цикла с постусловием, с указанием высоты и ширины)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <returns>Precondition Block (Блок цикла с постусловием)</returns>
        public Bitmap PostconditionBlock(int width, int height)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, 0), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Postcondition block with indication of height and width, text
        /// (Блок цикла с постусловием, с указанием высоты и ширины, текста)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Precondition Block (Блок цикла с постусловием)</returns>
        public Bitmap PostconditionBlock(int width, int height, string text)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, 0), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / (width / 2), height - parametrs.font.Size * 2);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Postcondition block with indication of height and width, text, block color
        /// (Блок цикла с постусловием, с указанием высоты и ширины, текста, цвета блока)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Precondition Block (Блок цикла с постусловием)</returns>
        public Bitmap PostconditionBlock(Color color, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, 0), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / (width / 2), height - parametrs.font.Size * 2);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Postcondition block with indication of height and width, text, block color, text color
        /// (Блок цикла с постусловием, с указанием высоты и ширины, текста, цвета блока, цвета текста)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Precondition Block (Блок цикла с постусловием)</returns>
        public Bitmap PostconditionBlock(Color color, Color fontColor, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, 0), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, height / 2), new Point(width, height / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / (width / 2), height - parametrs.font.Size * 2);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Postcondition block with indication of height and width, text, block color, text color, outline color
        /// (Блок цикла с постусловием, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Precondition Block (Блок цикла с постусловием)</returns>
        public Bitmap PostconditionBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, 0), new Point(width / 4, height / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, height / 2), new Point(width, height  / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / (width / 2), height - parametrs.font.Size * 2);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Postcondition block with indication of height and width, text, block color, text color, outline color, added width
        /// (Блок цикла с постусловием, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура, добавленная высота)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <returns>Precondition Block (Блок цикла с постусловием)</returns>
        public Bitmap PostconditionBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, 0), new Point(width / 4, (height + addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, (height + addHeight) / 2), new Point(width, (height + addHeight) / 2));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / (width / 2), height - parametrs.font.Size * 2);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Postcondition block with indication of height and width, text, block color, text color, outline color, added width, font
        /// (Блок цикла с постусловием, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура, добавленная высота, шрифта)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="addHeight">Добавленная высота (Added Width)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <returns>Precondition Block (Блок цикла с постусловием)</returns>
        public Bitmap PostconditionBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text, int addHeight, Font font)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, 0), new Point(width / 4, (height + addHeight) / 2));
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, (height + addHeight) / 2), new Point(width, (height + addHeight) / 2));
            graf.DrawString(text, font, new SolidBrush(fontColor), width / (width / 2), height - font.Size * 2);
            graf.Dispose();
            return Block;
        }
        #endregion
        #region SubroutineBlock
        /// <summary>
        /// Subroutine block
        /// (Блок подпрограммы)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock()
        {
            DrawRectangle(Color.White, Color.Black, 52, 28);
            graf.FillRectangle(new SolidBrush(Color.Gray), 1, 1, 13, 26);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(13, 0), new Point(13, 28));
            graf.FillRectangle(new SolidBrush(Color.Gray), 39, 1, 12, 26);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(39, 0), new Point(39, 28));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width
        /// (Блок подпрограммы, с указанием высоты и ширины)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(int width, int height)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.FillRectangle(new SolidBrush(Color.Gray), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(Color.Gray), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width, text
        /// (Блок подпрограммы, с указанием высоты и ширины, текста)
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(int width, int height, string text)
        {
            DrawRectangle(Color.White, Color.Black, width, height);
            graf.FillRectangle(new SolidBrush(Color.Gray), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(Color.Gray), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width, text, block color
        /// (Блок подпрограммы, с указанием высоты и ширины, текста, цвета блока)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(Color color, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.FillRectangle(new SolidBrush(Color.Gray), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(Color.Gray), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(Color.Black), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width, text, block color, text color
        /// (Блок подпрограммы, с указанием высоты и ширины, текста, цвета блока, цвета текста)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(Color color, Color fontColor, int width, int height, string text)
        {
            DrawRectangle(color, Color.Black, width, height);
            graf.FillRectangle(new SolidBrush(Color.Gray), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(Color.Gray), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(Color.Black, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width, text, block color, text color, outline color
        /// (Блок подпрограммы, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвет контура)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(Color color, Color fontColor, Color contrColor, int width, int height, string text)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.FillRectangle(new SolidBrush(Color.Gray), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(Color.Gray), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width, text, block color, text color, outline color, frame color
        /// (Блок подпрограммы, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвета контура, цвета рамок)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="frameColor">Цвет рамки (Frame Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(Color color, Color fontColor, Color contrColor, Color frameColor, int width, int height, string text)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.FillRectangle(new SolidBrush(frameColor), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(frameColor), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, height / 2 - parametrs.font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width, text, block color, text color, outline color, frame color, font
        /// (Блок подпрограммы, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвета контура, цвета рамок, шрифта)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="frameColor">Цвет рамки (Frame Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(Color color, Color fontColor, Color contrColor, Color frameColor, int width, int height, string text, Font font)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.FillRectangle(new SolidBrush(frameColor), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(frameColor), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.DrawString(text, font, new SolidBrush(fontColor), width / 2, height / 2 - font.Size, parametrs.drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width, text, block color, text color, outline color, frame color, drawing format
        /// (Блок подпрограммы, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвета контура, цвета рамок, формата отрисовки)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="frameColor">Цвет рамки (Frame Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(Color color, Color fontColor, Color contrColor, Color frameColor, int width, int height, string text, StringFormat drawFormat)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.FillRectangle(new SolidBrush(frameColor), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(frameColor), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.DrawString(text, parametrs.font, new SolidBrush(fontColor), width / 2, height / 2 - parametrs.font.Size, drawFormat);
            graf.Dispose();
            return Block;
        }


        /// <summary>
        /// Subroutine block with indication of height and width, text, block color, text color, outline color, frame color, font, drawing format
        /// (Блок подпрограммы, с указанием высоты и ширины, текста, цвета блока, цвета текста, цвета контура, цвета рамок, шрифта, формата отрисовки)
        /// <param name="color">Цвет блока (Block Color)</param>
        /// <param name="fontColor">Цвет текста (Text Color)</param>
        /// <param name="contrColor">Цвет контура (Outline Color)</param>
        /// <param name="frameColor">Цвет рамки (Frame Color)</param>
        /// <param name="width">Ширина (Width)</param>
        /// <param name="height">Высота (Height)</param>
        /// <param name="text">Текст (Text)</param>
        /// <param name="font">Шрифт (Font)</param>
        /// <param name="drawFormat">Drawing format (Формат отрисовки)</param>
        /// <returns>Subroutine Block (Блок подпрограммы)</returns>
        public Bitmap SubroutineBlock(Color color, Color fontColor, Color contrColor, Color frameColor, int width, int height, string text, Font font, StringFormat drawFormat)
        {
            DrawRectangle(color, contrColor, width, height);
            graf.FillRectangle(new SolidBrush(frameColor), 1, 1, width / 4, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width / 4, 0), new Point(width / 4, height));
            graf.FillRectangle(new SolidBrush(frameColor), width - width / 4, 1, width / 4 - 1, height - 2);
            graf.DrawLine(new Pen(contrColor, 1), new Point(width - width / 4, 0), new Point(width - width / 4, height));
            graf.DrawString(text, font, new SolidBrush(fontColor), width / 2, height / 2 - font.Size, drawFormat);
            graf.Dispose();
            return Block;
        }
        #endregion
    }
}
