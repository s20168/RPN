using NUnit.Framework;
using System;
using RPN;
using RPN.Exceptions;

namespace RPNTest {
	[TestFixture]
	public class RPNTest {
		private RPN.RPN _sut;
		[SetUp]
		public void Setup() {
			_sut = new RPN.RPN();
		}
		[Test]
		public void CheckIfTestWorks() {
			Assert.Pass();
		}

		[Test]
		public void CheckIfCanCreateSut() {
			Assert.That(_sut, Is.Not.Null);
		}

		[Test]
		public void SingleDigitOneInputOneReturn() {
			var result = _sut.EvalRPN("1");

			Assert.That(result, Is.EqualTo(1));

		}
		[Test]
		public void SingleDigitOtherThenOneInputNumberReturn() {
			var result = _sut.EvalRPN("2");

			Assert.That(result, Is.EqualTo(2));

		}
		[Test]
		public void TwoDigitsNumberInputNumberReturn() {
			var result = _sut.EvalRPN("12");

			Assert.That(result, Is.EqualTo(12));

		}
		[Test]
		public void TwoNumbersGivenWithoutOperator_ThrowsException() {
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("1 2"));

		}
		[Test]
		public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 2 +");

			Assert.That(result, Is.EqualTo(3));
		}
		[Test]
		public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("2 2 *");

			Assert.That(result, Is.EqualTo(4));
		}
		[Test]
		public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 2 -");

			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void ComplexExpression() {
			var result = _sut.EvalRPN("15 7 1 1 + - / 3 * 2 1 1 + + -");

			Assert.That(result, Is.EqualTo(4));
		}
		
		// -----------
		[Test]
		public void DividingTwoNums_WhereModuloIsZero_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("2 6 /");
			
			Assert.That(result, Is.EqualTo(3));
		}
		
		[Test]
		public void DividingTwoNums_WhereModuloIsNotZero_ReturnsCorrectResult_AsInteger()
		{
			var result = _sut.EvalRPN("2 5 /");
			
			Assert.That(result, Is.Not.EqualTo(2.5));
			Assert.That(result, Is.EqualTo(2));
		}
		
		[Test]
		public void DividingTwoNums_WhereDividendIsZero_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("15 0 /");
			
			Assert.That(result, Is.EqualTo(0));
		}
		
		[Test]
		public void DividingTwoNums_WhereDivisorIsZero_ThrowsException()
		{
			Assert.Throws<DivideByZeroException>(() => _sut.EvalRPN("0 15 /"));
		}
		
		[Test]
		public void ConvertBinary_ToDecimal_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("B101");
			
			Assert.That(result, Is.EqualTo(5));
		}
		
		[Test]
		public void ConvertHex_ToDecimal_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("#AB");

			Assert.That(result, Is.EqualTo(171));
		}
		
		[Test]
		public void ConvertDecimal_ToDecimal_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("D10");
			
			Assert.That(result, Is.EqualTo(10));
		}

		[Test]
		public void AddingTwoBinaryNums_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("B11 B100 +");
			
			Assert.That(result, Is.EqualTo(7));
		}

		[Test]
		public void AddingTwoNums_FromDifferentNumeralSys_ReturnsCorrectResult()
		{
			var resultBIN_DEC = _sut.EvalRPN("#BA D13 +");
			Assert.That(resultBIN_DEC, Is.EqualTo(199));
			
			var resultBinHex = _sut.EvalRPN("B101 #AB +");
			Assert.That(resultBinHex, Is.EqualTo(176));
			
			var resultDEC_HEX = _sut.EvalRPN("D2 #8 +");
			Assert.That(resultDEC_HEX, Is.EqualTo(10));
			
			var resultNUM_HEX = _sut.EvalRPN("2 #8 +");
			Assert.That(resultNUM_HEX, Is.EqualTo(10));
		}

		[Test]
		public void FactoringNum_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("5 !");

			Assert.That(result, Is.EqualTo(120));
		}
		
		[Test]
		public void AddingNum_ToFactoredNum_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("5 ! 2 +");

			Assert.That(result, Is.EqualTo(122));
		}

		[Test]
		public void SquareRootingNum_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("100 sqrt");
			
			Assert.That(result, Is.EqualTo(10));
		}
		
		[Test]
		public void SquareRootingNum_ReturnsCorrectResult_RoundedDown()
		{
			var result = _sut.EvalRPN("15 sqrt");
			
			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public void InsertingAbsoluteValue_ReturnsCorrectResult()
		{
			var result = _sut.EvalRPN("|-20|");

			Assert.That(result, Is.EqualTo(20));
		}

		[Test]
		public void Exponent_RaisesNum_ToPowerOfTwo()
		{
			var result = _sut.EvalRPN("8 ^");
			
			Assert.That(result, Is.EqualTo(64));
		}

		[Test]
		public void Calculate_ComplexExpression()
		{
			var result = _sut.EvalRPN("8 9 ^ |-3| + 100 + 256 sqrt + /");

			Assert.That(result, Is.EqualTo(25));
		}

		[Test]
		public void First_IncorrectOperation_ThrowsException()
		{
			Assert.Throws<InvalidElementException>(() => _sut.EvalRPN("C101"));
		}
		
		[Test]
		public void Second_IncorrectOperation_ThrowsException()
		{
			Assert.Throws<InvalidElementException>(() => _sut.EvalRPN("#AB]"));
		}
		
		[Test]
		public void Third_IncorrectOperation_ThrowsException()
		{
			Assert.Throws<InvalidElementException>(() => _sut.EvalRPN("Baa"));
		}
		
		[Test]
		public void Fourth_IncorrectOperation_ThrowsException()
		{
			Assert.Throws<InvalidElementException>(() => _sut.EvalRPN("5 5 $"));
		}
		
		[Test]
		public void Fifth_IncorrectOperation_ThrowsException()
		{
			Assert.Throws<InvalidElementException>(() => _sut.EvalRPN("#GAB"));
		}
		
		[Test]
		public void Sixth_IncorrectOperation_ThrowsException()
		{
			Assert.Throws<InvalidElementException>(() => _sut.EvalRPN("|43f|"));
		}
	}
}