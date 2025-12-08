import React, { useState } from 'react';
import {
  View,
  Text,
  ScrollView,
  TouchableOpacity,
  StyleSheet,
  SafeAreaView,
  ProgressBarAndroidProps,
} from 'react-native';
import { Ionicons } from '@expo/vector-icons';

const ProgressScreen = () => {
  const [timeRange, setTimeRange] = useState('week');

  const progressData = {
    week: [
      { day: 'Mon', score: 78, quizzes: 2 },
      { day: 'Tue', score: 82, quizzes: 3 },
      { day: 'Wed', score: 88, quizzes: 2 },
      { day: 'Thu', score: 0, quizzes: 0 },
      { day: 'Fri', score: 85, quizzes: 4 },
      { day: 'Sat', score: 91, quizzes: 3 },
{ day: 'Sun', score: 87, quizzes: 2 },
    ],
  };

  const overallStats = {
    totalQuizzes: 123,
  correctAnswers: 2456,
    totalAnswers: 2850,
  avgScore: 86,
    strongTopics: ['Advanced Math', 'Vocabulary', 'Writing'],
    weakTopics: ['Algebra', 'Reading Inference'],
  };

  const chartData = progressData[timeRange];
  const maxScore = Math.max(...chartData.map((d) => d.score || 0));

  const ProgressChart = () => (
    <View style={styles.chartContainer}>
      <View style={styles.chartHeader}>
   <Text style={styles.chartTitle}>Score Trend</Text>
        <View style={styles.timeRangeButtons}>
          {['week', 'month'].map((range) => (
    <TouchableOpacity
              key={range}
     style={[
          styles.timeRangeButton,
     timeRange === range && styles.timeRangeButtonActive,
  ]}
      onPress={() => setTimeRange(range)}
   >
              <Text
       style={[
    styles.timeRangeText,
      timeRange === range && styles.timeRangeTextActive,
     ]}
     >
        {range === 'week' ? 'Week' : 'Month'}
            </Text>
         </TouchableOpacity>
       ))}
     </View>
      </View>

      <View style={styles.chart}>
        <View style={styles.yAxis}>
 <Text style={styles.yLabel}>100</Text>
          <Text style={styles.yLabel}>50</Text>
          <Text style={styles.yLabel}>0</Text>
        </View>

 <View style={styles.bars}>
          {chartData.map((data, index) => (
      <View key={index} style={styles.barContainer}>
              <View style={styles.barWrapper}>
       <View
             style={[
   styles.bar,
         {
             height: data.score ? `${(data.score / maxScore) * 100}%` : '0%',
           backgroundColor: data.score === 0 ? '#E0E0E0' : '#4CAF50',
        },
        ]}
           />
              </View>
  <Text style={styles.barLabel}>{data.day}</Text>
            </View>
          ))}
 </View>
      </View>
    </View>
  );

  return (
    <SafeAreaView style={styles.container}>
      <ScrollView showsVerticalScrollIndicator={false}>
        {/* Header */}
   <View style={styles.header}>
   <Text style={styles.headerTitle}>My Progress</Text>
       <Text style={styles.headerSubtitle}>Track your improvement</Text>
        </View>

        {/* Overall Score Card */}
        <View style={styles.scoreCard}>
          <View style={styles.scoreContent}>
            <Text style={styles.scoreLabel}>Current Average</Text>
            <Text style={styles.scoreValue}>{overallStats.avgScore}%</Text>
            <Text style={styles.scoreIndicator}>? 8% from last week</Text>
        </View>
          <View style={styles.scoreCircle}>
            <View style={styles.circleBorder}>
      <Text style={styles.circleText}>{overallStats.avgScore}%</Text>
       </View>
          </View>
        </View>

        {/* Progress Chart */}
        <ProgressChart />

        {/* Statistics */}
        <Text style={styles.sectionTitle}>Statistics</Text>
        <View style={styles.statsContainer}>
          <View style={styles.statItem}>
        <Ionicons name="checkmark-circle" size={32} color="#4CAF50" />
        <Text style={styles.statValue}>{overallStats.totalQuizzes}</Text>
            <Text style={styles.statLabel}>Quizzes Completed</Text>
        </View>
          <View style={styles.statItem}>
            <Ionicons name="trophy" size={32} color="#FFC107" />
            <Text style={styles.statValue}>
      {overallStats.correctAnswers}/{overallStats.totalAnswers}
   </Text>
       <Text style={styles.statLabel}>Correct Answers</Text>
     </View>
        </View>

        {/* Accuracy by Section */}
        <Text style={styles.sectionTitle}>Accuracy by Section</Text>
        <View style={styles.sectionsContainer}>
          {[
   { name: 'Reading', accuracy: 82 },
            { name: 'Writing', accuracy: 88 },
            { name: 'Math', accuracy: 91 },
          ].map((section, index) => (
            <View key={index} style={styles.sectionAccuracy}>
 <View style={styles.sectionHeader}>
    <Text style={styles.sectionName}>{section.name}</Text>
    <Text style={styles.accuracyPercent}>{section.accuracy}%</Text>
            </View>
      <View style={styles.accuracyBar}>
       <View
  style={[
    styles.accuracyFill,
          {
             width: `${section.accuracy}%`,
     backgroundColor: getAccuracyColor(section.accuracy),
        },
       ]}
    />
              </View>
  </View>
      ))}
    </View>

      {/* Strong & Weak Topics */}
        <View style={styles.topicsContainer}>
  <View style={styles.topicSection}>
<View style={styles.topicHeader}>
   <Ionicons name="star" size={20} color="#FFD700" />
    <Text style={styles.topicTitle}>Strong Topics</Text>
            </View>
         {overallStats.strongTopics.map((topic, index) => (
    <View key={index} style={styles.topicBadge}>
        <Ionicons name="checkmark" size={14} color="#4CAF50" />
     <Text style={styles.topicText}>{topic}</Text>
      </View>
         ))}
          </View>

<View style={styles.topicSection}>
            <View style={styles.topicHeader}>
  <Ionicons name="alert-circle" size={20} color="#FF6B6B" />
      <Text style={styles.topicTitle}>Areas to Improve</Text>
            </View>
       {overallStats.weakTopics.map((topic, index) => (
              <View key={index} style={styles.topicBadge}>
         <Ionicons name="alert-circle-sharp" size={14} color="#FF6B6B" />
 <Text style={styles.topicText}>{topic}</Text>
  </View>
       ))}
      </View>
        </View>

        {/* Recommendations */}
        <Text style={styles.sectionTitle}>Personalized Recommendations</Text>
     <View style={styles.recommendationsContainer}>
     <View style={styles.recommendationCard}>
  <Ionicons name="bulb" size={24} color="#FFC107" />
            <View style={styles.recommendationContent}>
     <Text style={styles.recommendationTitle}>Focus on Weak Areas</Text>
   <Text style={styles.recommendationText}>
            Spend more time on Algebra practice to improve accuracy
       </Text>
   </View>
          </View>

          <View style={styles.recommendationCard}>
            <Ionicons name="fitness" size={24} color="#2196F3" />
  <View style={styles.recommendationContent}>
         <Text style={styles.recommendationTitle}>Practice Consistency</Text>
         <Text style={styles.recommendationText}>
   Complete 2-3 quizzes daily for better retention
   </Text>
     </View>
          </View>
     </View>

        {/* Goal Setting */}
        <Text style={styles.sectionTitle}>Your Goal</Text>
        <View style={styles.goalCard}>
          <View style={styles.goalHeader}>
      <Text style={styles.goalTitle}>Target Score: 1500</Text>
            <Text style={styles.goalDate}>By June 2024</Text>
          </View>
    <View style={styles.progressContainer}>
          <View style={styles.progressBar}>
  <View style={[styles.progressFill, { width: '57%' }]} />
  </View>
            <Text style={styles.progressText}>
              860 / 1500 points · 57% Complete
     </Text>
    </View>
      </View>
 </ScrollView>
    </SafeAreaView>
  );
};

const getAccuracyColor = (accuracy) => {
  if (accuracy >= 90) return '#4CAF50';
  if (accuracy >= 75) return '#FFC107';
  return '#FF6B6B';
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
  scoreCard: {
    marginHorizontal: 16,
    marginVertical: 16,
    paddingVertical: 20,
    paddingHorizontal: 16,
    backgroundColor: '#FFFFFF',
    borderRadius: 12,
  flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    elevation: 2,
  },
  scoreContent: {
    flex: 1,
  },
  scoreLabel: {
    fontSize: 12,
    color: '#999',
    fontWeight: '500',
  },
  scoreValue: {
    fontSize: 36,
    fontWeight: 'bold',
    color: '#2196F3',
    marginTop: 4,
  },
scoreIndicator: {
  fontSize: 12,
    color: '#4CAF50',
marginTop: 8,
    fontWeight: '500',
  },
  scoreCircle: {
    width: 100,
    height: 100,
    justifyContent: 'center',
    alignItems: 'center',
  },
  circleBorder: {
    width: 90,
    height: 90,
    borderRadius: 45,
    borderWidth: 3,
  borderColor: '#2196F3',
    justifyContent: 'center',
    alignItems: 'center',
  },
  circleText: {
    fontSize: 20,
    fontWeight: 'bold',
    color: '#2196F3',
  },
  chartContainer: {
    marginHorizontal: 16,
    marginVertical: 16,
    paddingVertical: 16,
    paddingHorizontal: 16,
    backgroundColor: '#FFFFFF',
    borderRadius: 12,
    elevation: 1,
  },
  chartHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 16,
  },
  chartTitle: {
    fontSize: 16,
    fontWeight: '600',
    color: '#333',
  },
  timeRangeButtons: {
    flexDirection: 'row',
    gap: 8,
  },
  timeRangeButton: {
    paddingHorizontal: 12,
    paddingVertical: 6,
    borderRadius: 6,
    backgroundColor: '#F5F5F5',
  },
  timeRangeButtonActive: {
    backgroundColor: '#2196F3',
  },
  timeRangeText: {
    fontSize: 12,
    fontWeight: '600',
    color: '#999',
  },
  timeRangeTextActive: {
    color: '#FFFFFF',
  },
  chart: {
    height: 200,
    flexDirection: 'row',
    alignItems: 'flex-end',
    gap: 8,
  },
  yAxis: {
    justifyContent: 'space-between',
    paddingRight: 8,
    height: '100%',
  },
  yLabel: {
    fontSize: 10,
    color: '#999',
  },
  bars: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'flex-end',
    gap: 6,
  },
  barContainer: {
    flex: 1,
    alignItems: 'center',
  },
  barWrapper: {
    width: '100%',
    height: 150,
    justifyContent: 'flex-end',
  },
  bar: {
    width: '100%',
    borderRadius: 4,
  },
  barLabel: {
    fontSize: 10,
    color: '#999',
    marginTop: 6,
  },
  sectionTitle: {
    fontSize: 16,
  fontWeight: '600',
    marginBottom: 12,
    marginLeft: 20,
 marginTop: 8,
    color: '#333',
  },
  statsContainer: {
    marginHorizontal: 16,
    flexDirection: 'row',
  gap: 12,
    marginBottom: 24,
  },
  statItem: {
    flex: 1,
 paddingVertical: 16,
    paddingHorizontal: 12,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    alignItems: 'center',
elevation: 1,
  },
  statValue: {
 fontSize: 18,
    fontWeight: 'bold',
    color: '#2196F3',
    marginTop: 8,
  },
  statLabel: {
 fontSize: 11,
    color: '#999',
    marginTop: 4,
    textAlign: 'center',
  },
  sectionsContainer: {
    marginHorizontal: 16,
    marginBottom: 24,
  },
  sectionAccuracy: {
    marginBottom: 12,
    paddingVertical: 12,
    paddingHorizontal: 14,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    elevation: 1,
  },
  sectionHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginBottom: 8,
  },
  sectionName: {
    fontSize: 14,
    fontWeight: '600',
    color: '#333',
  },
  accuracyPercent: {
    fontSize: 14,
    fontWeight: 'bold',
    color: '#2196F3',
  },
  accuracyBar: {
    height: 8,
    backgroundColor: '#E0E0E0',
    borderRadius: 4,
    overflow: 'hidden',
  },
  accuracyFill: {
    height: '100%',
    borderRadius: 4,
  },
  topicsContainer: {
    marginHorizontal: 16,
    marginBottom: 24,
    gap: 16,
  },
  topicSection: {
  paddingVertical: 14,
    paddingHorizontal: 14,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    elevation: 1,
  },
  topicHeader: {
  flexDirection: 'row',
    alignItems: 'center',
 marginBottom: 10,
    gap: 8,
  },
  topicTitle: {
    fontSize: 14,
    fontWeight: '600',
    color: '#333',
  },
  topicBadge: {
    flexDirection: 'row',
 alignItems: 'center',
    paddingVertical: 6,
    gap: 8,
  },
  topicText: {
    fontSize: 13,
    color: '#666',
  },
  recommendationsContainer: {
    marginHorizontal: 16,
    marginBottom: 24,
    gap: 10,
  },
  recommendationCard: {
    flexDirection: 'row',
    paddingVertical: 12,
    paddingHorizontal: 14,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    alignItems: 'flex-start',
    gap: 12,
    elevation: 1,
  },
  recommendationContent: {
    flex: 1,
  },
  recommendationTitle: {
    fontSize: 13,
    fontWeight: '600',
    color: '#333',
    marginBottom: 2,
  },
  recommendationText: {
    fontSize: 12,
    color: '#666',
    lineHeight: 18,
},
  goalCard: {
    marginHorizontal: 16,
    marginBottom: 24,
    paddingVertical: 16,
    paddingHorizontal: 14,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    elevation: 1,
  },
  goalHeader: {
marginBottom: 12,
  },
  goalTitle: {
    fontSize: 15,
    fontWeight: '600',
    color: '#333',
  },
  goalDate: {
    fontSize: 12,
    color: '#999',
    marginTop: 4,
  },
  progressContainer: {
    gap: 8,
  },
  progressBar: {
    height: 8,
    backgroundColor: '#E0E0E0',
    borderRadius: 4,
    overflow: 'hidden',
  },
  progressFill: {
    height: '100%',
    backgroundColor: '#4CAF50',
 borderRadius: 4,
  },
  progressText: {
    fontSize: 12,
    color: '#666',
  },
});

export default ProgressScreen;
