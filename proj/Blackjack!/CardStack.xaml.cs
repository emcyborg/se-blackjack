﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blackjack {
    /// <summary>
    /// Interaction logic for CardStack.xaml
    /// </summary>
    public partial class CardStack : UserControl {
        private List<Card> cards;

        public List<Card> Cards {
            get {
                return cards;
            }
            set {
                cards = value;
                draw();
            }
        }

        public void Add(Rank r, Suit s) {
            cards.Add(new Card(r, s));
            draw();
        }

        public void Clear() {
            cards.Clear();
        }

        public CardStack() {
            InitializeComponent();
            cards = new List<Card>();
        }

        /// <summary>
        /// Draws cards on the control.
        /// </summary>
        private void draw() {
            stack.Children.Clear();
            if (cards != null)
                foreach (Card c in cards) {
                    Image cardDisplay = getCardImage(c);
                    cardDisplay.Margin = new Thickness(0, 0, -64, 0);
                    stack.Children.Add(cardDisplay);
                    // TODO: Distribute cards evenly
                }
        }

        /// <summary>
        /// Returns the appropriate image for a given Card. If the given Card is null, then the back of a card is returned.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private Image getCardImage(Card c) {
            Func<Rank, Suit, string, string> getFilename = (rn, su, ext) => {
                    string rnk, sut;
                    switch (rn) {
                        case Rank.Ace:
                            rnk = "1";
                            break;
                        case Rank.Two:
                            rnk = "2";
                            break;
                        case Rank.Three:
                            rnk = "3";
                            break;
                        case Rank.Four:
                            rnk = "4";
                            break;
                        case Rank.Five:
                            rnk = "5";
                            break;
                        case Rank.Six:
                            rnk = "6";
                            break;
                        case Rank.Seven:
                            rnk = "7";
                            break;
                        case Rank.Eight:
                            rnk = "8";
                            break;
                        case Rank.Nine:
                            rnk = "9";
                            break;
                        case Rank.Ten:
                            rnk = "10";
                            break;
                        case Rank.Jack:
                            rnk = "j";
                            break;
                        case Rank.Queen:
                            rnk = "q";
                            break;
                        case Rank.King:
                            rnk = "k";
                            break;
                        default:
                            rnk = null;
                            break;
                    }
                    switch (su) {
                        case Suit.Hearts:
                            sut = "h";
                            break;
                        case Suit.Spades:
                            sut = "s";
                            break;
                        case Suit.Diamonds:
                            sut = "d";
                            break;
                        case Suit.Clubs:
                            sut = "c";
                            break;
                        default:
                            sut = null;
                            break;
                    }
                    return sut + rnk + "." + ext;
                };

            Image cardImg = new Image();
            cardImg.Width = 80;
            BitmapImage cardBMP = new BitmapImage();
            cardBMP.BeginInit();
            if (c != null)
                cardBMP.UriSource = new Uri(@"/Blackjack!;component/cards_png/" +
                    getFilename(c.Rank, c.Suit, "png"), UriKind.Relative);
            else
                cardBMP.UriSource = new Uri(@"/Blackjack!;component/cards_png/b1fv.png", UriKind.Relative);
            cardBMP.EndInit();
            cardImg.Source = cardBMP;
            return cardImg;
        }
    }
}
