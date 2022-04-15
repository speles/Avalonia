﻿using System;

namespace Avalonia.Styling
{
    /// <summary>
    /// The `&amp;` nesting style selector.
    /// </summary>
    internal class NestingSelector : Selector
    {
        public override bool InTemplate => false;
        public override bool IsCombinator => false;
        public override Type? TargetType => null;

        public override string ToString() => "&";

        protected override SelectorMatch Evaluate(IStyleable control, IStyle? parent, bool subscribe)
        {
            if (parent is Style s && s.Selector is Selector selector)
            {
                return selector.Match(control, null, subscribe);
            }

            throw new InvalidOperationException(
                "Nesting selector was specified but cannot determine parent selector.");
        }

        protected override Selector? MovePrevious() => null;
    }
}