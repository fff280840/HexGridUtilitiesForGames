﻿#region The MIT License - Copyright (C) 2012-2013 Pieter Geerkens
/////////////////////////////////////////////////////////////////////////////////////////
//                PG Software Solutions Inc. - Hex-Grid Utilities
/////////////////////////////////////////////////////////////////////////////////////////
// The MIT License:
// ----------------
// 
// Copyright (c) 2012-2013 Pieter Geerkens (email: pgeerkens@hotmail.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, 
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to 
// permit persons to whom the Software is furnished to do so, subject to the following 
// conditions:
//     The above copyright notice and this permission notice shall be 
//     included in all copies or substantial portions of the Software.
// 
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//     EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//     OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//     NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
//     HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
//     WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
//     FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
//     OTHER DEALINGS IN THE SOFTWARE.
/////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PG_Napoleonics.Utilities {
  /// <summary>Fast (but unstable) implementation of PriorityQueue.</summary>
  /// <typeparam name="TPriority"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  public sealed class HeapPriorityQueue<TPriority,TValue> : IPriorityQueue<TPriority,TValue>
    where TPriority : struct, IComparable<TPriority>, IEquatable<TPriority>
  {
    IHeap<KeyValuePair<TPriority,TValue>> heap = new MinListHeap<KeyValuePair<TPriority,TValue>>();

    public bool IsEmpty { get { return heap.IsEmpty; } }

    public void Enqueue(TPriority priority, TValue value) {
      heap.Add(new KeyValuePair<TPriority,TValue>(priority, value));
    }

    public TValue Dequeue() { return heap.ExtractFirst().Value; }

    public KeyValuePair<TPriority,TValue> Peek() { return heap.Peek(); }
  }
}
