# Regex

## What is Regex?

In theoretical computer science and formal language theory, a regular expression \(sometimes called a rational expression; _regex_ in short\) is a sequence of characters that defines a search pattern, mainly for use in pattern matching with strings, or string matching, i.e. “find and replace”- like operations.

## How to Use It

The following examples of regex usage were written by Jim Hollenhorst, the author of a free [Expresso](http://www.ultrapico.com/Expresso.htm) application for developing and testing of .NET regular expressions. You can find the whole article [here](https://www.codeproject.com/Articles/9099/The-30-Minute-Regex-Tutorial).

### **Searching for Elvis**

**1:** `elvis` _Find elvis_

This is a perfectly valid regular expression that searches for an exact sequence of characters. In .NET, options can be set to ignore the case of characters, so this expression will match “Elvis”, “ELVIS”, or “eLvIs”. Note it will also match the last five letters of the word “pelvis”. We can improve the expression as follows:

**2:** `\belvis\b` _Find elvis as a whole word_

Now things are getting a little more interesting. The `\b` is a special code that means, “match the position at the beginning or end of any word”. This expression will only match complete words spelled “elvis” with any combination of lowercase or capital letters.

**3:** `\belvis\b.*\balive\b` _Find text with “elvis” followed by “alive”_

To find all the lines in which the word “elvis” is followed by the word “alive.” The period or dot \(`.`\) is a special code that matches any character other than a newline. The asterisk means to repeat the previous term as many times as necessary to guarantee a match. Thus, `.*` means “match any number of characters other than newline”. It is now a simple matter to build an expression that means “search for the word ‘elvis’ followed on the same line by the word ‘alive’.”

With just a few special characters we are beginning to build powerful regular expressions and they are already becoming hard for us humans to read.

Let’s try another example.

### **Determining the Validity of Phone Numbers**

A Web page collects a customer’s seven-digit phone number and we want to verify that the phone number is in the correct format, say “xxx-xxxx”, where each “x” is a digit. The following expression will search through text looking for such string:

**4:** `\b\d\d\d-\d\d\d\d` _Find seven-digit phone number_

Each `\d` means “match any single digit”. The `-` has no special meaning and is interpreted literally, matching a hyphen. To avoid repetition, use a shorthand notation that means the same thing:

**5:** `\b\d{3}-\d4` _Find a seven-digit phone number in a better way_

The `{3}` following the `\d` means “repeat the preceding character three times”.

## Basics of .NET Regular Expressions

Let’s explore some of the basics of regular expressions in .NET.

### **Special Characters**

You should get to know a few characters with special meaning. You have already learned about `\b`, `.`, `*`, and `\d`. To match any whitespace characters, like spaces, tabs, and newlines, use `\s` . Similarly, `\w` matches any alphanumeric character.

**6:** `\ba\w*\b` _Find words that start with the letter “a”_

This works by searching for the beginning of a word \(`\b`\), then the letter “a”, then any number of repetitions of alphanumeric characters \(`\w*`\), then the end of a word \(`\b`\).

**7:** `\d+` _Find repeated strings of digits_

Here, the `+` is similar to `*`, except it requires at least one repetition.

**8:** `\b\w6\b` _Find six letter words_

Here is a table of some of the characters with special meaning:

| Special character | Function |
| :--- | :--- |
| `.` | Match any character except newline |
| `\w` | Match any alphanumeric character |
| `\s` | Match any whitespace character |
| `\d` | Match any digit |
| `\b` | Match the beginning or end of a word |
| `^` | Match the beginning of the string |
| `$` | Match the end of the string |

_**Table 1.** Commonly used special characters for regular expressions_

**At the beginning**

The special characters `^` and `$` are used when looking for something that must start at the beginning of the text and/or end at the end of the text. This is especially useful for validating input in which the entire text must match a pattern. For example, to validate a seven-digit phone number, use:

**9:** `^\d{3}-\d4$` _Validate a seven-digit phone number_

This is the same as example \(5\) but forced to fill the whole text string, with nothing else before or after the matched text. By setting the “Multiline” option in .NET, `^` and `$` change their meaning to match the beginning and end of a single line of text, rather than the entire text string.

#### **Escaped characters**

A problem occurs if user wants to match one of the special characters, like ““ or `$`. Use the backslash to remove the special meaning. Thus, `\`, `.` and `\`, match the literal characters `^`, `.` and `\`, respectively.

#### **Repetitions**

`{3}` and `*` can be used to indicate repetition of a single character. The same syntax can be used to repeat entire subexpressions. There are several other ways to specify a repetition, as shown in this table:

| Quantifier | Function |
| :--- | :--- |
| `*` | Repeat any number of times |
| `+` | Repeat one or more times |
| `?` | Repeat zero or one time |
| `{n}` | Repeat n times |
| `{n,m}` | Repeat at least n, but no more than m times |
| `{n,}` | Repeat at least n times |

_**Table 2.** Commonly used quantifiers_

#### Examples

**10:** `\b\w{5,6}\b` _Find all five and six letter words_

**11:** `\b\d{3}\s\d{3}-\d4` _Find ten digit phone numbers_

**12:** `\d{3}-\d2-\d4` _Social security number_

**13:** `^\w*` _The first word in the line or in the text_

### **Character Classes**

Finding more complex set of characters can be done by listing the desired characters within square brackets. Thus, `[aeiou]` matches any vowel and `[.?!]` matches the punctuation at the end of a sentence. In this example, the `.` and `?` characters lose their special meanings within square brackets and are interpreted literally. A range of characters can also be specified, so `[a-z0-9]` means: “match any lowercase letter of the alphabet, or any digit”.

Complex expression that searches for telephone numbers:

**14:** `\(?\d{3}[) ]\s?\d{3}[- ]\d4` _A ten digit phone number_

This expression will find phone numbers in several formats, like “\(800\) 325-3535” or “650 555 1212”. The`\(?` searches for zero or one left parentheses, `[) ]` searches for a right parenthesis or a space. The `\s?` searches for zero or one whitespace characters. Note, it will also find cases like “650\) 555-1212” in which the parenthesis is not balanced. Below are some alternatives to eliminate this problem.

#### **Negation**

The following table shows how to search for a character that is NOT a member of an easily defined class of characters.

| Negation character | Function |
| :--- | :--- |
| `\W` | Match any character that is NOT alphanumeric |
| `\S` | Match any character that is NOT whitespace |
| `\D` | Match any character that is NOT a digit |
| `\B` | Match a position that is NOT the beginning or end of a word |
| `[^x]` | Match any character that is NOT x |
| `[^aeiou]` | Match any character that is NOT one of the characters aeiou |

_**Table 3.** How to specify what you don’t want_

**15:** `\S+` _All strings that do not contain whitespace characters_

#### **Alternatives**

To switch between several alternatives, allowing a match if either one is satisfied, use the pipe `|` symbol to separate the alternatives. For example, Zip Codes come in two flavors, one with 5 digits, the other with 9 digits and a hyphen. We can find either with this expression:

**16:** `\b\d5-\d4\b|\b\d5\b` _Five and nine digit Zip Codes_

When using alternatives, the order is important since the matching algorithm will attempt to match the leftmost alternative first. If the order is reversed in this example, the expression will only find the 5 digit Zip Codes and fail to find the 9 digit ones. Alternatives can be used to improve the expression for ten digit phone numbers, allowing the area code to appear either delimited by whitespace or parenthesis:

**17:** `(\(\d{3}\)|\d{3})\s?\d{3}[- ]\d4` _Ten digit phone numbers, a better way_

#### Grouping

Parentheses can be used to delimit a subexpression to allow repetition or other special treatment. For example:

**18:** `(\d{1,3}\.){3}\d{1,3}` _A simple IP address finder_

The first part of the expression searches for a one to three digit number followed by a literal period `.`. This is enclosed in parentheses and repeated three times using the `{3}` quantifier, followed by the same expression without the trailing period.

Note, this example allows IP addresses with arbitrary one, two, or three digit numbers separated by periods even though a valid IP address cannot have numbers larger than 255. It would be useful to arithmetically compare a captured number N to enforce N<256, but this is not possible with regular expressions alone.

The below example tests various alternatives based on the starting digits to guarantee the limited range of numbers by pattern matching. This shows that an expression can become cumbersome even when looking for a pattern that is simple to describe.

**19:** `((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)` _IP finder_

When subexpressions are grouped with parentheses, the text that matches the subexpression is available for further processing in a computer program or within the regular expression itself. By default, groups are numbered sequentially as encountered in reading from left to right, starting with 1.

A “backreference” is used to search for a recurrence of previously matched text that has been captured by a group. For example, `\1` means, “match the text that was captured by group 1”. Here is an example:

**20:** `\b(\w+)\b\s*\1\b` _Find repeated words_

This works by capturing a string of at least one alphanumeric character within group 1 `(\w+)`, but only if it begins and ends a word. It then looks for any amount of whitespace `\s*` followed by a repetition of the captured text `\1` ending at the end of a word.

It is possible to override the automatic numbering of groups by specifying an explicit name or number. In the above example, instead of writing the group as `(\w+)`, it is possible to write it as `?(\w+)` to name this capture group “Word”. A backreference to this group is written `\k`. For example:

**21:** `\b(?<Word>\w+)\b\s*\k<Word>\b` _Capture repeated word in a named group_

Using parentheses, there are many special purpose syntax elements available. Some of the most common are summarized in this table:

| **Captures** |  |
| :--- | :--- |
| `(exp)` | Match exp and capture it in an automatically numbered group |
| `(?<name>exp)` | Match exp and capture it in a group named name |
| `(?:exp)` | Match exp, but do not capture it |

| **Lookarounds** |  |
| :--- | :--- |
| `(?=exp)` | Match any position preceding a suffix exp |
| `(?<=exp)` | Match any position following a prefix exp |
| `(?!exp)` | Match any position after which the suffix exp is not found |
| `(?<!exp)` | Match any position before which the prefix exp is not found |

| **Comment** |  |
| :--- | :--- |
| `(?#comment)` | Comment |

_**Table 4.** Commonly used Group Constructs_

`(?:exp)` does not alter the matching behavior, it just doesn’t capture it in a named or numbered group like the first two.

#### **Positive Lookaround**

The next four are so-called _lookahead_ or _lookbehind_ assertions. They look for things that go before or after the current match without including them in the match. It is important to understand that these expressions match a position like `^` or `\b` and never match any text. For this reason, they are known as “zero-width assertions”. For example:

`(?=exp)` is the “zero-width positive lookahead assertion”. It matches a position in the text that precedes a given suffix, but doesn’t include the suffix in the match:

**22:** `\b\w+(?=ing\b)` _The beginning of words ending with “ing”_

`(?<=exp)` is the “zero-width positive lookbehind assertion”. It matches the position following a prefix, but does not include the prefix in the match:

**23:** `(?<=\bre)\w+\b` _The end of words starting with “re”_

An example that could be used repeatedly to insert commas into numbers in groups of three digits:

**24:** `(?<=\d)\d{3}\b` _Three digits at the end of a word, preceded by a digit_

An example that looks for both a prefix and a suffix:

**25:** `(?<=\s)\w+(?=\s)` _Alphanumeric strings bounded by whitespace_

#### **Negative Lookaround**

How to verify that a character is not present, without matching anything? For example, searching for words in which the letter “q” is not followed by the letter “u”:

**26:** `\b\w*q[^u]\w*\b` _Words with “q” followed by NOT “u”_

Note, it fails when “q” is the last letter of a word, as in “Iraq”. This is because `[^q]` always matches a character. If “q” is the last character of the word, it will match the white space character that follows, so in the example the expression ends up matching two whole words. Negative lookaround solves this problem because it matches a position and does not consume any text. As with positive lookaround, it can also be used to match the position of an arbitrarily complex subexpression, rather than just a single character:

**27:** `\b\w*q(?!u)\w*\b` _Search for words with “q” not followed by “u”_

“Zero-width negative lookahead assertion”, `(?!exp)`, was used, which succeeds only if the suffix `exp` is not present.

**28:** `\d{3}(?!\d)` _Three digits not followed by another digit_

`(?<!exp)`, the “zero-width negative lookbehind assertion” can be used, to search for a position in the text at which the prefix `exp` is not present:

**29:** `(?<![a-z ])\w7` _Strings of 7 alphanumerics not preceded by a letter or space_

**30:** `(?<=<(\w+)>).*(?=<\/\1>)` _Text between HTML tags_

This searches for an HTML tag using lookbehind and the corresponding closing tag using lookahead, thus capturing the intervening text but excluding both tags.

#### **Comments please**

Another use of parentheses is to include comments using the `(?#comment)` syntax. A better method is to set the “Ignore Pattern Whitespace” option, which allows whitespace to be inserted in the expression and then ignored when the expression is used. With this option set, anything following a number sign `#` at the end of each line of text is ignored. For example, we can format the preceding example like this:

**31:** Text between HTML tags, with comments

```text
(?<=    # Search for a prefix, but exclude it
  <(\w+)> # Match a tag of alphanumerics within angle brackets
)       # End the prefix
.* # Match any text
(?=     # Search for a suffix, but exclude it
  <\/\1>  # Match the previously captured tag preceded by "/"
  )       # End the suffix
```

#### Greedy and Lazy

When a regular expression has a quantifier that can accept a range of repetitions \(like `.*`\), the normal behavior is to match as many characters as possible. Consider the following regular expression:

**32:** `a.*b` _The longest string starting with a and ending with b_

If this is used to search the string “aabab”, it will match the entire string “aabab”. This is called “greedy” matching. Sometimes, “lazy” matching is preferred in which a match using the minimum number of repetitions is found. All the quantifiers in Table 2 can be turned into “lazy” quantifiers by adding a question mark `?`. Thus `*?` means “match any number of repetitions, but use the smallest number of repetitions that still leads to a successful match”. Lazy version of example \(32\):

**33:** `a.*?b` _The shortest string starting with a and ending with b_

If applied this to the same string “aabab” it will first match “aab” and then “ab”.

| Quantifier | Function |
| :--- | :--- |
| `*?` | Repeat any number of times, but as few as possible |
| `+?` | Repeat one or more times, but as few as possible |
| `??` | Repeat zero or one time, but as few as possible |
| `{n,m}?` | Repeat at least n, but no more than m times, but as few as possible |
| `{n,}?` | Repeat at least n times, but as few as possible |

_**Table 5.** Lazy quantifiers_

#### **Other expressions**

| Expression | Function |
| :--- | :--- |
| `\a` | Bell character |
| `\b` | Normally a word boundary, but within a character class it means backspace |
| `\t` | Tab |
| `\r` | Carriage return |
| `\v` | Vertical tab |
| `\f` | Form feed |
| `\n` | New line |
| `\e` | Escape |
| `\nnn` | Character whose ASCII octal code is _nnn_ |
| `\xnn` | Character whose hexadecimal code is _nn_ |
| `\unnnn` | Character whose Unicode is _nnnn_ |
| `\cN` | Control N character, for example carriage return \(Ctrl-M\) is `\cM` |
| `\A` | Beginning of a string \(like `^` but does not depend on the multiline option\) |
| `\Z` | End of string or before `\n` at end of string \(ignores multiline\) |
| `\z` | End of string \(ignores multiline\) |
| `\G` | Beginning of the current search |
| `\pname` | Any character from the Unicode class named _name_, for example `\pIsGreek` |
| `(?>exp)` | Greedy subexpression, also known as a non-backtracking subexpression. This is matched only once and then does not participate in backtracking. |
| `(?<x>-<y>exp)` or `(?-<y>exp)` | Balancing group. It allows named capture groups to be manipulated on a push down/pop up stack and can be used, for example, to search for matching parentheses, which is otherwise not possible with regular expressions. |
| `(?im-nsx:exp)` | Change the regular expression options for the subexpression _exp_ |
| `(?im-nsx)` | Change the regular expression options for the rest of the enclosing group |
| `(?(exp)yes\|no)` | The subexpression exp is treated as a zero-width positive lookahead. If it matches at this point, the subexpression _yes_ becomes the next match, otherwise _no_ is used. |
| `(?(exp)yes)` | Same as above but with an empty no expression |
| `(?(name)yes\|no)` | This is the same syntax as the preceding case. If name is a valid group name, the _yes_ expression is matched if the named group had a successful match, otherwise the _no_ expression is matched. |
| `(?(name)yes)` | Same as above but with an empty _no_ expression |

_**Table 6.** Everything we left out. The left-hand column shows the number of an example in the project file that illustrates this construct._

