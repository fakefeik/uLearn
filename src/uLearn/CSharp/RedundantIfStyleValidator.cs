using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace uLearn.CSharp
{
	public class RedundantIfStyleValidator : BaseStyleValidator
	{
		protected override IEnumerable<string> ReportAllErrors(SyntaxTree userSolution)
		{
			return InspectAll<IfStatementSyntax>(userSolution, Inspect);
		}

		public IEnumerable<string> Inspect(IfStatementSyntax ifElseStatement)
		{
			bool trueStatementIsReturnBoolLiteral =
				(ifElseStatement.Statement as ReturnStatementSyntax)
					.Call(r => r.Expression as LiteralExpressionSyntax)
					.Call(IsBoolLiteral, false);
			bool? falseStatementIsReturnBoolLiteral =
				ifElseStatement.Else
					.Call(e => e.Statement as ReturnStatementSyntax)
					.Call(r => r.Expression as LiteralExpressionSyntax)
					.Call(e => (bool?)IsBoolLiteral(e), null);

			var nextSibling = ifElseStatement.Parent.ChildNodes().SkipWhile(n => n != ifElseStatement).Skip(1).FirstOrDefault();
			falseStatementIsReturnBoolLiteral = falseStatementIsReturnBoolLiteral ?? 
								(nextSibling as ReturnStatementSyntax)
									.Call(r => r.Expression as LiteralExpressionSyntax)
									.Call(IsBoolLiteral, false);
			if (trueStatementIsReturnBoolLiteral && falseStatementIsReturnBoolLiteral == true)
				yield return Report(ifElseStatement, "����������� return ������ if");
		}

		private static bool IsBoolLiteral(LiteralExpressionSyntax node)
		{
			var token = node.Token.Kind();
			return token == SyntaxKind.TrueKeyword || token == SyntaxKind.FalseKeyword;
		}
	}
}