using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Exceptions.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShuntingYardAlgorithm.Config
{
    internal class OperatorTokenConfig
    {
        private readonly Dictionary<string, EOperator.OperatorType> operatorType = new Dictionary<string, EOperator.OperatorType>();
        private readonly Dictionary<EOperator.OperatorType, int> precedence = new Dictionary<EOperator.OperatorType, int>();

        private static Lazy<OperatorTokenConfig> lazy = new Lazy<OperatorTokenConfig>(() => new OperatorTokenConfig(), true);
        private static OperatorTokenConfig instance { get => lazy.Value; }

        private OperatorTokenConfig()
        {
            try
            {
                SetOperatorType();
                SetPrecedence();
            }
            catch(Exception ex)
            {

            }
        }

        private void SetPrecedence()
        {
            precedence[EOperator.OperatorType.And] = 10;
            precedence[EOperator.OperatorType.Or] = 5;
        }

        internal static int GetPrecedence(EOperator.OperatorType operatorType)
        {
            lock (instance)
            {
                if(instance.precedence.ContainsKey(operatorType) == false)
                {
                    throw new OperatorTypeNotSupportedException();
                }
                return instance.precedence[operatorType];
            }
        }

        internal static EOperator.OperatorType GetOperatorType(string type)
        {
            lock (instance)
            {
                if(instance.operatorType.ContainsKey(type) == false)
                {
                    throw new OperatorTypeNotSupportedException();
                }

                return instance.operatorType[type];
            }
        }

        private void SetOperatorType()
        {
            operatorType["&"] = EOperator.OperatorType.And;
            operatorType["|"] = EOperator.OperatorType.Or;

        }
                
    }
}
