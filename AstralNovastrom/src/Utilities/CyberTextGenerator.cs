namespace AstralNovastrom.src.Utilities
{
    public static class CyberTextGenerator
    {
        private static readonly char[] CyberChars = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', '|', ';', ':', ',', '.', '<', '>', '?', '/',
            'α', 'β', 'γ', 'δ', 'ε', 'ζ', 'η', 'θ', 'ι', 'κ', 'λ', 'μ', 'ν', 'ξ', 'ο', 'π', 'ρ', 'σ', 'τ', 'υ', 'φ', 'χ', 'ψ', 'ω'
        };

        private static readonly Random Random = new Random();

        public static string GenerateRandomText(int length)
        {
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = CyberChars[Random.Next(CyberChars.Length)];
            }
            return new string(result);
        }

        public static string GenerateGlitchedText(string originalText, double glitchProbability = 0.1)
        {
            char[] result = originalText.ToCharArray();
            for (int i = 0; i < result.Length; i++)
            {
                if (Random.NextDouble() < glitchProbability)
                {
                    result[i] = CyberChars[Random.Next(CyberChars.Length)];
                }
            }
            return new string(result);
        }

        public static string GenerateCyberPhrase(int words = 3)
        {
            string[] prefixes = { "Neo", "Cyber", "Tech", "Quantum", "Nano", "Digital", "Synth", "Bio" };
            string[] middles = { "Core", "Net", "Matrix", "System", "Protocol", "Algorithm", "Interface", "Processor" };
            string[] suffixes = { "X", "V2", "Prime", "Ultra", "Pro", "Max", "Elite", "Alpha" };

            string result = string.Empty;
            for (int i = 0; i < words; i++)
            {
                result += prefixes[Random.Next(prefixes.Length)];
                result += middles[Random.Next(middles.Length)];
                result += suffixes[Random.Next(suffixes.Length)];
                if (i < words - 1)
                {
                    result += "-";
                }
            }
            return result;
        }

        public static string GenerateErrorText(int length = 20)
        {
            string[] errorPrefixes = { "ERROR_", "FAULT_", "CRITICAL_", "WARNING_" };
            string prefix = errorPrefixes[Random.Next(errorPrefixes.Length)];
            string suffix = GenerateRandomText(length - prefix.Length);
            return prefix + suffix;
        }

        public static string GenerateIpAddress()
        {
            return $"{Random.Next(256)}.{Random.Next(256)}.{Random.Next(256)}.{Random.Next(256)}";
        }

        public static string GenerateMacAddress()
        {
            string[] chars = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string result = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                result += chars[Random.Next(chars.Length)];
                result += chars[Random.Next(chars.Length)];
                if (i < 5)
                {
                    result += ":";
                }
            }
            return result;
        }
    }
}
