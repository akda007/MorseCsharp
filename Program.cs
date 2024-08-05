using System.Text.RegularExpressions;

var morseMap = new Dictionary<char, string>() {
    { 'a', ".-" }, { 'b', "-..." }, { 'c', "-.-." }, { 'd', "-.." },
    { 'e', "." }, { 'f', "..-." }, { 'g', "--." }, { 'h', "...." },
    { 'i', ".." }, { 'j', ".---" }, { 'k', "-.-" }, { 'l', ".-.." },
    { 'm', "--" }, { 'n', "-." }, { 'o', "---" }, { 'p', ".--." },
    { 'q', "--.-" }, { 'r', ".-." }, { 's', "..." }, { 't', "-" },
    { 'u', "..-" }, { 'v', "...-" }, { 'w', ".--" }, { 'x', "-..-" },
    { 'y', "-.--" }, { 'z', "--.." },

    { '1', ".----" }, { '2', "..---" }, { '3', "...--" }, { '4', "....-" }, { '5', "....." },
    { '6', "-...." }, { '7', "--..." }, { '8', "---.." }, { '9', "----." }, {'0', "-----"},
    { ' ', "/"}
};

string ConvertToMorse(string value) {
    var result = value.ToLower()
        .Where(x => char.IsLetterOrDigit(x) || x == ' ')
        .Select(x => morseMap[x])
        .ToList();
    
    return string.Join(' ', result);
}


void PlayMorse(string morse) {
    foreach (var value in morse) {
        (int duration, int frequency) = value switch {
            '.' => (140, 550),
            '-' => (260, 550),
            ' ' => (250, 0),
            _ => (200, 0)
        };

        if (frequency > 0) 
            Console.Beep(frequency, duration);

        Thread.Sleep(duration);
    }
}

var morse = ConvertToMorse(Console.ReadLine());
Console.WriteLine();

PlayMorse(morse);