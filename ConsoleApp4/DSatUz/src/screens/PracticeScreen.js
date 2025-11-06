import React, { useState } from 'react';
import {
  View,
  Text,
  ScrollView,
  TouchableOpacity,
  StyleSheet,
  SafeAreaView,
  TextInput,
} from 'react-native';
import { Ionicons } from '@expo/vector-icons';

const PracticeScreen = () => {
  const [selectedCategory, setSelectedCategory] = useState('all');
  const [searchText, setSearchText] = useState('');

  const categories = [
    { id: 'all', name: 'All Topics', count: 450 },
    { id: 'reading', name: 'Reading', count: 120 },
    { id: 'writing', name: 'Writing', count: 110 },
    { id: 'math', name: 'Math', count: 140 },
  ];

  const practiceQuizzes = [
    {
      id: '1',
  title: 'Literary Passages',
      category: 'reading',
      difficulty: 'Medium',
      questions: 15,
      avgTime: '12 min',
      icon: 'book',
    },
    {
      id: '2',
      title: 'Grammar Basics',
      category: 'writing',
  difficulty: 'Easy',
      questions: 20,
      avgTime: '8 min',
      icon: 'pencil',
    },
    {
      id: '3',
      title: 'Algebra Fundamentals',
      category: 'math',
      difficulty: 'Medium',
   questions: 18,
      avgTime: '15 min',
      icon: 'calculator',
    },
    {
 id: '4',
      title: 'Vocabulary Building',
      category: 'reading',
      difficulty: 'Hard',
      questions: 25,
      avgTime: '18 min',
      icon: 'library',
    },
    {
      id: '5',
      title: 'Advanced Math',
category: 'math',
      difficulty: 'Hard',
      questions: 20,
      avgTime: '20 min',
      icon: 'calculator',
    },
    {
 id: '6',
      title: 'Punctuation Rules',
      category: 'writing',
      difficulty: 'Easy',
      questions: 15,
    avgTime: '10 min',
      icon: 'pencil',
    },
  ];

  const filteredQuizzes =
    selectedCategory === 'all'
      ? practiceQuizzes
      : practiceQuizzes.filter((q) => q.category === selectedCategory);

  const getDifficultyColor = (difficulty) => {
    switch (difficulty) {
      case 'Easy':
        return '#4CAF50';
      case 'Medium':
        return '#FFC107';
    case 'Hard':
        return '#FF6B6B';
      default:
        return '#999';
    }
  };

  const QuizCard = ({ quiz }) => (
    <TouchableOpacity style={styles.quizCard}>
      <View style={styles.quizHeader}>
      <View style={styles.quizIcon}>
          <Ionicons name={quiz.icon} size={28} color="#2196F3" />
        </View>
        <View style={styles.quizInfo}>
          <Text style={styles.quizTitle}>{quiz.title}</Text>
          <View style={styles.quizMeta}>
            <Text style={styles.quizMetaText}>
          {quiz.questions} questions
   </Text>
            <Text style={styles.metaDot}>•</Text>
   <Text style={styles.quizMetaText}>{quiz.avgTime}</Text>
          </View>
     </View>
        <Ionicons name="chevron-forward" size={20} color="#999" />
      </View>

      <View style={styles.quizFooter}>
        <View
          style={[
            styles.difficultyBadge,
      { borderColor: getDifficultyColor(quiz.difficulty) },
          ]}
      >
      <Text
            style={[
              styles.difficultyText,
              { color: getDifficultyColor(quiz.difficulty) },
         ]}
          >
       {quiz.difficulty}
          </Text>
</View>
        <TouchableOpacity style={styles.startButton}>
          <Text style={styles.startButtonText}>Start</Text>
        </TouchableOpacity>
      </View>
    </TouchableOpacity>
  );

  return (
    <SafeAreaView style={styles.container}>
      <View style={styles.header}>
        <Text style={styles.headerTitle}>Practice Quizzes</Text>
    <Text style={styles.headerSubtitle}>Master each topic step by step</Text>
      </View>

      {/* Search Bar */}
      <View style={styles.searchContainer}>
        <Ionicons name="search" size={20} color="#999" />
      <TextInput
          style={styles.searchInput}
  placeholder="Search quizzes..."
          placeholderTextColor="#999"
          value={searchText}
          onChangeText={setSearchText}
  />
      </View>

    {/* Category Tabs */}
      <ScrollView
     horizontal
        showsHorizontalScrollIndicator={false}
        style={styles.categoriesScroll}
      >
        <View style={styles.categoriesContainer}>
          {categories.map((cat) => (
            <TouchableOpacity
            key={cat.id}
      style={[
      styles.categoryTab,
                selectedCategory === cat.id && styles.categoryTabActive,
]}
              onPress={() => setSelectedCategory(cat.id)}
       >
              <Text
          style={[
         styles.categoryTabText,
            selectedCategory === cat.id && styles.categoryTabTextActive,
         ]}
        >
  {cat.name}
            </Text>
         <Text
           style={[
        styles.categoryCount,
    selectedCategory === cat.id && styles.categoryCountActive,
  ]}
              >
                {cat.count}
              </Text>
      </TouchableOpacity>
          ))}
</View>
      </ScrollView>

      {/* Quiz List */}
      <ScrollView showsVerticalScrollIndicator={false}>
        <View style={styles.quizzesContainer}>
          {filteredQuizzes.map((quiz) => (
            <QuizCard key={quiz.id} quiz={quiz} />
   ))}
        </View>

        {/* Stats Section */}
        <View style={styles.statsSection}>
          <Text style={styles.statsSectionTitle}>Your Practice Stats</Text>
     <View style={styles.statsGrid}>
       <View style={styles.statBox}>
              <Text style={styles.statBoxValue}>87</Text>
 <Text style={styles.statBoxLabel}>Quizzes Completed</Text>
          </View>
      <View style={styles.statBox}>
    <Text style={styles.statBoxValue}>1,850</Text>
              <Text style={styles.statBoxLabel}>Questions Answered</Text>
  </View>
            <View style={styles.statBox}>
       <Text style={styles.statBoxValue}>85%</Text>
   <Text style={styles.statBoxLabel}>Avg Accuracy</Text>
    </View>
          </View>
        </View>

  {/* Streak Section */}
        <View style={styles.streakCard}>
          <Ionicons name="flame" size={32} color="#FF6B6B" />
          <View style={styles.streakContent}>
            <Text style={styles.streakTitle}>Keep the Streak Going!</Text>
     <Text style={styles.streakText}>
  You have a 12-day practice streak. Complete one quiz today!
    </Text>
      </View>
        </View>
    </ScrollView>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#F5F5F5',
  },
  header: {
    paddingHorizontal: 20,
    paddingVertical: 16,
    backgroundColor: '#2196F3',
  },
  headerTitle: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#FFFFFF',
  },
  headerSubtitle: {
    fontSize: 13,
    color: 'rgba(255, 255, 255, 0.8)',
    marginTop: 4,
  },
  searchContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginHorizontal: 16,
    marginVertical: 12,
    paddingHorizontal: 12,
    paddingVertical: 8,
backgroundColor: '#FFFFFF',
    borderRadius: 8,
    gap: 8,
  },
  searchInput: {
    flex: 1,
    fontSize: 14,
    color: '#333',
  },
  categoriesScroll: {
    flexGrow: 0,
  },
categoriesContainer: {
    flexDirection: 'row',
    paddingHorizontal: 16,
    paddingVertical: 8,
    gap: 8,
  },
  categoryTab: {
    paddingHorizontal: 14,
    paddingVertical: 8,
    backgroundColor: '#FFFFFF',
    borderRadius: 20,
    borderWidth: 1,
    borderColor: '#E0E0E0',
  },
  categoryTabActive: {
    backgroundColor: '#2196F3',
    borderColor: '#2196F3',
  },
  categoryTabText: {
    fontSize: 12,
    fontWeight: '600',
    color: '#666',
  },
  categoryTabTextActive: {
    color: '#FFFFFF',
  },
  categoryCount: {
    fontSize: 10,
    color: '#999',
    marginTop: 2,
  },
  categoryCountActive: {
    color: 'rgba(255, 255, 255, 0.8)',
  },
  quizzesContainer: {
 paddingHorizontal: 16,
    paddingVertical: 12,
  },
quizCard: {
    marginBottom: 12,
    paddingVertical: 14,
    paddingHorizontal: 14,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    elevation: 1,
  },
  quizHeader: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 12,
    gap: 12,
  },
  quizIcon: {
    width: 48,
    height: 48,
    borderRadius: 8,
    backgroundColor: '#F0F8FF',
    justifyContent: 'center',
    alignItems: 'center',
  },
  quizInfo: {
    flex: 1,
  },
  quizTitle: {
    fontSize: 14,
    fontWeight: '600',
    color: '#333',
  },
  quizMeta: {
    flexDirection: 'row',
    alignItems: 'center',
    marginTop: 2,
  },
  quizMetaText: {
    fontSize: 11,
    color: '#999',
  },
  metaDot: {
    marginHorizontal: 4,
    color: '#999',
  },
  quizFooter: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
  paddingTop: 10,
    borderTopWidth: 1,
    borderTopColor: '#F0F0F0',
  },
  difficultyBadge: {
    paddingHorizontal: 10,
    paddingVertical: 5,
    borderRadius: 12,
    borderWidth: 1,
  },
  difficultyText: {
    fontSize: 11,
    fontWeight: '600',
  },
  startButton: {
    paddingHorizontal: 14,
    paddingVertical: 6,
    backgroundColor: '#2196F3',
    borderRadius: 6,
  },
  startButtonText: {
    fontSize: 12,
    fontWeight: '600',
    color: '#FFFFFF',
  },
  statsSection: {
    marginHorizontal: 16,
    marginVertical: 16,
  },
  statsSectionTitle: {
    fontSize: 16,
    fontWeight: '600',
    color: '#333',
    marginBottom: 12,
  },
  statsGrid: {
    flexDirection: 'row',
    gap: 10,
  },
  statBox: {
    flex: 1,
    paddingVertical: 14,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    alignItems: 'center',
    elevation: 1,
  },
  statBoxValue: {
    fontSize: 20,
    fontWeight: 'bold',
    color: '#2196F3',
    marginBottom: 4,
  },
  statBoxLabel: {
    fontSize: 10,
    color: '#999',
    textAlign: 'center',
  },
  streakCard: {
    marginHorizontal: 16,
    marginVertical: 16,
    marginBottom: 24,
  paddingVertical: 16,
    paddingHorizontal: 14,
    backgroundColor: '#FFFFFF',
borderRadius: 10,
    flexDirection: 'row',
    alignItems: 'center',
    gap: 12,
elevation: 1,
  },
  streakContent: {
    flex: 1,
  },
  streakTitle: {
    fontSize: 14,
    fontWeight: '600',
    color: '#333',
  },
  streakText: {
    fontSize: 12,
    color: '#666',
    marginTop: 2,
  },
});

export default PracticeScreen;
