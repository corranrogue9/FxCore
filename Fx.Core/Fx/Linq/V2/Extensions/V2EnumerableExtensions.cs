using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.V2;

namespace Fx.Linq.V2.Extensions
{
    public interface IExtendedEnumerable<TElement>
    {
        public IV2Enumerable<TElement> Source { get; }
    }

    public static class V2EnumerableExtensions
    {
        public static IExtendedEnumerable<TElement> Extend2<TElement>(this IV2Enumerable<TElement> source, Func<IV2Enumerable<TElement>, IExtendedEnumerable<TElement>> extensionFactory)
        {
            throw new NotImplementedException();
        }

        public static IV2Enumerable<TElement> Extend<TElement>(this IV2Enumerable<TElement> source, Func<IV2Enumerable<TElement>, IV2Enumerable<TElement>> extensionFactory)
        {
/*
TODO
this who thing is a mess
let's first look at just a single "extension" framework, we'll call "garrett extension"
garrett extensions wants to override concat because it knows that, if you call where on a concat, you could call where on the individual sequences and concat the result, and if the individual sequences have any perf improvement on where, then this new concat mechanism will preseve those perf improvements
if garrett extensions implements iconcatenumerable, this works for the above, and everything is great
however, the caller needs to decide whether to add the garrett extension or not; there should be a clear boundary for these callers, and they shouldn't need to know all of the details of the extension to do it right
so, if the caller has two sequences, it's natural to say "ok, this is the boundary, i'm going to add garrett extensions to these two sequences, and then never again"; however, if one of those sequences overrides where, and they add garrett extensions as described above, then garrett extensions (being that it only implements iconcatenumerable) will not delegate to the smarter iwhereenumerable
so, to define this clear boundary for our callers, garrett extensions will need to implement all of the override interfaces just so that it can delegate to the "source" sequence

if the we take this route, then a new override interface that is introduced will similarly be blocked by garrett extensions until garrett extensions ship an update
we could:
1. accept this
2. define a different boundary for when callers should add their extensions
3. add a framework for all extensions to leverage; i don't now what this would look like exactly, but if we do this, then the framework itself will have the same problem as garrett extensions until the framework is update for each new override interface, but at least once the framework is updated all of the extensions can start benefitting from the new interfaces
    a. if the framework is *not* external to the v2enumerable, on the other hand, then it would be able to update the framework in the same update as the override interface

none of the above takes into account the problem of also having "christof extensions" on top of garrett extensions, though fixing the above may natural fix this composition issue
*/

            if (source is ExtendedEnumerable<TElement> extended)
            {
                ////return new ExtendedEnumerable()
                //// TODO
            }

            return new ExtendedEnumerable<TElement>(source, extensionFactory);
        }

        private sealed class ExtendedEnumerable<TElement> : IV2Enumerable<TElement>, IWhereEnumerable<TElement>
        {
            public ExtendedEnumerable(IV2Enumerable<TElement> source, Func<IV2Enumerable<TElement>, IV2Enumerable<TElement>> extensionFactory)
            {
                this.Source = source;
                this.ExtensionFactory = extensionFactory;
            }

            public IV2Enumerable<TElement> Source { get; }

            public Func<IV2Enumerable<TElement>, IV2Enumerable<TElement>> ExtensionFactory { get; }

            public IEnumerator<TElement> GetEnumerator()
            {
                return this.Source.GetEnumerator();
            }

            public IV2Enumerable<TElement> Where(Func<TElement, bool> predicate)
            {
                if (this.Source is IWhereEnumerable<TElement> where)
                {
                    return where.Where(predicate).Extend(this.ExtensionFactory);
                }

                return this.Source.Where(predicate).Extend(this.ExtensionFactory);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}
