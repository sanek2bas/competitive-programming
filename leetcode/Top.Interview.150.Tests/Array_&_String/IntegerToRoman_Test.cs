﻿using Top.Interview._150.Array___String;

namespace Array___String;

public class IntegerToRoman_Test
{
    [Test]
    [Arguments(3, "III")]
    [Arguments(58, "LVIII")]
    [Arguments(1994, "MCMXCIV")]
    public async Task IntegerToRoman(int num, string answer)
    {
        var solution = new IntegerToRoman();
        var result = solution.Execute(num);
        await Assert.That(result).IsEqualTo(answer);
    }
}
