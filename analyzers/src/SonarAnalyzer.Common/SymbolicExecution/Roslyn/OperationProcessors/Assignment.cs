﻿/*
 * SonarAnalyzer for .NET
 * Copyright (C) 2015-2022 SonarSource SA
 * mailto: contact AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using StyleCop.Analyzers.Lightup;

namespace SonarAnalyzer.SymbolicExecution.Roslyn.OperationProcessors
{
    internal static class Assignment
    {
        public static ProgramState Process(SymbolicContext context, ISimpleAssignmentOperationWrapper assignment)
        {
            var rightSide = context.State[assignment.Value];
            var newState = context.State
                .SetOperationValue(assignment.Target, rightSide)
                .SetOperationValue(assignment.WrappedOperation, rightSide);
            return newState.ResolveCapture(assignment.Target).TrackedSymbol() is { } symbol
                ? newState.SetSymbolValue(symbol, rightSide)
                : newState;
        }
    }
}