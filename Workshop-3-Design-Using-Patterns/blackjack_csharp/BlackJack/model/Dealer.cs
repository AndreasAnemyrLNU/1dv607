﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;

        private rules.IWinnerStrategy m_winnerRule;


        // TODO testing herer
        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            //m_hitRule = a_rulesFactory.Get17Rule();

            // TODO GetWinnerStrategy is hardcoden at momens
            m_winnerRule = a_rulesFactory.GetWinnerStrategy();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            // Uses strategy pattern. Easy to add new...
            return this.m_winnerRule.calcWinner(this, a_player, g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }


        // 151021 Seq.diagr. //AA

        public bool Stand()
        {
            if (m_deck != null) 
            {   
                ShowHand();

                while (m_hitRule.DoHit(this)) 
                {
                    this.GetNewCard(true, m_deck);
                }
            }
            return false;
        }
    }
}
