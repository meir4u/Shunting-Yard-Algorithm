using ShuntingYardAlgorithm.Base.Enum;
using ShuntingYardAlgorithm.Exceptions.Config;
using ShuntingYardAlgorithm.Exceptions.General;
using ShuntingYardAlgorithm.Exceptions.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShuntingYardAlgorithm.Config
{
    internal class ParentasiTokenConfig
    {
        private readonly Dictionary<string, EParentesi.ParentesiState> parentasiState = new Dictionary<string, EParentesi.ParentesiState>();
        private readonly Dictionary<EParentesi.ParentesiState, int> precedence = new Dictionary<EParentesi.ParentesiState, int>();

        private static Lazy<ParentasiTokenConfig> lazy = new Lazy<ParentasiTokenConfig>(() => new ParentasiTokenConfig(), true);
        private static ParentasiTokenConfig instance { get => lazy.Value; }

        private ParentasiTokenConfig()
        {
            try
            {
                SetParentesiState();
                SetPrecedence();
            }
            catch(Exception ex)
            {
                throw new ParentasiConfigException(ex.Message, ex);
            }
        }

        private void SetPrecedence()
        {
            precedence[EParentesi.ParentesiState.Open] = 0;
            precedence[EParentesi.ParentesiState.Close] = 0;
        }

        internal static int GetPrecedence(EParentesi.ParentesiState parentesiState)
        {
            lock (instance)
            {
                if(instance.precedence.ContainsKey(parentesiState) == false)
                {
                    throw new ParentesiStateNotSupportedException();
                }
                return instance.precedence[parentesiState];
            }
        }

        internal static EParentesi.ParentesiState GetParentasiState(string type)
        {
            lock (instance)
            {
                if(instance.parentasiState.ContainsKey(type) == false)
                {
                    throw new ParentesiStateNotSupportedException();
                }

                return instance.parentasiState[type];
            }
        }

        private void SetParentesiState()
        {
            parentasiState["("] = EParentesi.ParentesiState.Open;
            parentasiState[")"] = EParentesi.ParentesiState.Close;

        }
                
    }
}
