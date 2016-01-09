import string


class Dictionary(object):
	"""A dictionary that can determine if a set of characters is a word
	or if they are the beginning of a word.
	"""
	def __init__(self):
		self._words = set([])
		self._wordBeginnings = {}
		self._prepped = False

	def largestPossibleLength(self):
		"""determines the length of the largest word in the dictionary
		"""
		if not self._prepped:
			self._prepDictionary()
		return max(self._wordBeginnings.keys())+1

	def hasWords(self):
		"""determines if this Dictionary has words
		"""
		return len(self._words) > 0

	def loadWords(self, txtLine):
		"""takes a line of text and loads the unique words into 
		this dictionary.  Removes punctuation.
		"""
		strippedTxtLine = strip_punctuation(txtLine).upper()
		splitWords = strippedTxtLine.split()
		currentCount = len(self._words)
		for word in splitWords:
			self._words.add(word)
		
		self._prepped = self._prepped and (currentCount == len(self._words))
	def isWord(self, wordToCheck):
		"""determines if wordToCheck is in this dictionary
		"""
		return wordToCheck.upper() in self._words

	def isWordStart(self, toCheck):
		"""determines if toCheck is the beginning of a word in this dictionary
		"""
		if not self._prepped:
			self._prepDictionary()

		length = len(toCheck)
		return length in self._wordBeginnings.keys() and toCheck.upper() in self._wordBeginnings[len(toCheck)]
	
	def _prepDictionary(self):
		""" generates a set of the word beginnings at each length
		"""
		self._wordBeginnings = {}

		for word in self._words:
			self._addAllWordBeginnings(word)
		self._prepped = True

	def _addAllWordBeginnings(self, word):
		""" creates and modifies each set for word beginnings
		"""
		subWord = ""
		for char in word[:-1]:
			subWord += char
			if not len(subWord) in self._wordBeginnings.keys():
				self._wordBeginnings[len(subWord)] = set([])
			self._wordBeginnings[len(subWord)].add(subWord)


__replace_punctuation = string.maketrans(string.punctuation, ' '*len(string.punctuation))	
def strip_punctuation(s):
	"""repalce any punctuation with whitespace.  Prevents heart's becoming hearts
	"""
	return s.translate(__replace_punctuation)
	#return ''.join(c for c in s if c not in punctuation)