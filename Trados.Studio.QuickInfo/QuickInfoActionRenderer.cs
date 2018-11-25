﻿using QuickInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradosStudioQuickInfo
{
    public class QuickInfoActionRenderer
    {
        public static QuickInfoActionRenderer Instance = new QuickInfoActionRenderer();
        public static IEnumerable<QuickInfoAction> GenerateActions(string processorName, object resultNode)
        {
            return Instance.Generate(processorName, resultNode);
        }

        private IEnumerable<QuickInfoAction> Generate(string processorName, object resultNode)
        {
           if (resultNode is Node node)
            {

                var generatedActions = GenerateNode(processorName, node);

                foreach (var action in generatedActions)
                {
                    yield return action;
                }

            }

            else if (resultNode is string text)

            {

                yield return RenderText(processorName, text);

            }

            else if (resultNode is IEnumerable<object> list)

            {

                var generatedActions = GenerateList(processorName, list);
                foreach (var action in generatedActions)
                {
                    yield return action;
                }

            }
        }

        private IEnumerable<QuickInfoAction> GenerateList(string processorName, IEnumerable<object> list)
        {
            var actions = new List<QuickInfoAction>();
            foreach (var item in list)

            {
               actions.AddRange(Generate(processorName, item));

            }
            return actions;
        }

        private IEnumerable<QuickInfoAction> GenerateNode(string processorName, Node node)
        {

            if (node.Kind == "Table")

            {

                foreach (var row in node.List)
                {
                    yield return GenerateNodeRow(processorName, row);
                }

            }
            else

            {

                var text = GetText(node);

               yield return RenderText(processorName,text);

            }
        }

        private QuickInfoAction GenerateNodeRow(string processorName, object row)
        {
            StringBuilder text = new StringBuilder();

            if (row is Node node)
            {
                foreach (var cell in node.List)
                {
                    text.Append(GetText(cell as Node));
                    text.Append(" ");
                }
                text.Remove(text.Length - 1, 1);
            }

             return new QuickInfoAction(processorName, text.ToString());
        }

        private QuickInfoAction RenderText(string processorName, string text)
        {
            return new QuickInfoAction(processorName, text);
        }

        private string GetText(Node node)
        {
            return node.Text;
        }
    }
}
