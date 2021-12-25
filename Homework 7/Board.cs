using MapleUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Homework_7
{
    internal class Board
    {
        private const int CARD_BACK_TYPE = 3;
        public const int GENERATE_SEQURE = 6;

        private int cardBack;
        private readonly MainForm form;

        private readonly ButtonMatch?[] select;
        private readonly IList<ButtonMatch> buttonList;

        public Board(MainForm form)
        {
            this.form = form;
            select = new ButtonMatch?[2];
            buttonList = new List<ButtonMatch>();

            initCardBack();
            initButton();
        }

        private void initCardBack()
        {
            cardBack = MainForm.random.Next(CARD_BACK_TYPE);
        }

        public Image getCardBackground()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("card_back").Append(cardBack);
            return (Image)Properties.Resources.ResourceManager.GetObject(sb.ToString());
        }

        public IList<ButtonMatch> getButtonList()
        {
            return buttonList;
        }

        private void selectCard(int index)
        {
            for (int i = 0; i < select.Length; ++i)
            {
                if (i >= 1 && select[0].Value.button == buttonList[index].button)
                {
                    break;
                }
                else if (select[i] == null)
                {
                    select[i] = buttonList[index];
                    select[i].Value.button.Image = getCardImage(select[i].Value.symbol);
                    break;
                }
            }
            if (select[0] == null || select[1] == null)
            {
                return;
            }

            form.block = true;
            form.processCard(new Button[] { select[0].Value.button, select[1].Value.button }, select[0].Value.symbol == select[1].Value.symbol);
            select[0] = null;
            select[1] = null;
        }

        private void buttonClickEvent(object sender, EventArgs e)
        {
            form.sp.Stream = MapleSound.ButtonMouseClick;
            form.sp.Play();
            if (form.block)
            {
                return;
            }

            Button target = sender as Button;
            int index = int.Parse(target.Name.Substring(8));
            selectCard(index);
        }

        private void initButton()
        {
            IList<int> symbolList = new MatchGenerator().getSymbolList();
            for (int i = 0; i < Math.Pow(GENERATE_SEQURE, 2); ++i)
            {
                Button btnMatch = new Button()
                {
                    Enabled = false,
                    Image = getCardBackground(),
                    Location = new Point(12 + 55 * (i % 6), 12 + 68 * (i / 6)),
                    Name = "btnMatch" + i,
                    Size = new Size(49, 62),
                    TabStop = false
                };
                btnMatch.Click += new EventHandler(buttonClickEvent);
                // form.Controls.Add(btnMatch);
                // btnMatch.BringToFront();
                form.pbDeck.Controls.Add(btnMatch);
                buttonList.Add(new ButtonMatch()
                {
                    button = btnMatch,
                    symbol = symbolList[i]
                });
            }
        }

        private Image getCardImage(int card)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("card_").Append(card);
            return (Image)Properties.Resources.ResourceManager.GetObject(sb.ToString());
        }

        public void enableButton(bool enable)
        {
            foreach (ButtonMatch bm in buttonList)
            {
                bm.button.Enabled = enable;
            }
        }

        public void reset()
        {
            Application.DoEvents();
            for (int i = 0; i < select.Length; ++i)
            {
                select[i] = null;
            }
            foreach (ButtonMatch bm in buttonList)
            {
                form.pbDeck.Controls.Remove(bm.button);
            }
            buttonList.Clear();
            initCardBack();
            initButton();
        }
    }
}