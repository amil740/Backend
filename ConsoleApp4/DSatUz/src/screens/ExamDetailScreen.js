import React, { useState } from 'react';
import {
  View,
  Text,
  ScrollView,
  TouchableOpacity,
  StyleSheet,
  SafeAreaView,
} from 'react-native';
import { Ionicons } from '@expo/vector-icons';

const ExamDetailScreen = ({ route }) => {
  const { exam } = route.params;
  const [selectedSection, setSelectedSection] = useState(null);

  const sectionDetails = {
    Reading: {
    correct: 40,
      total: 52,
      avgTime: 3.5,
      topics: ['Passages', 'Vocabulary', 'Inference'],
    },
    Writing: {
      correct: 39,
      total: 44,
      avgTime: 2.1,
      topics: ['Grammar', 'Punctuation', 'Style'],
    },
    Math: {
    correct: 51,
      total: 58,
      avgTime: 2.8,
      topics: ['Algebra', 'Advanced Math', 'Geometry'],
    },
  };

  const getAccuracy = (correct, total) => ((correct / total) * 100).toFixed(1);

  return (
    <SafeAreaView style={styles.container}>
 <ScrollView showsVerticalScrollIndicator={false}>
  {/* Exam Header */}
        <View style={styles.header}>
    <Text style={styles.examTitle}>{exam.title}</Text>
  <Text style={styles.examDate}>{exam.date}</Text>
        </View>

        {/* Overall Score */}
        <View style={styles.scoreCard}>
      <View style={styles.scoreMain}>
      <Text style={styles.scoreLabel}>Total Score</Text>
      <View style={styles.scoreRow}>
         <Text style={styles.mainScore}>{exam.score}</Text>
      <Text style={styles.maxScore}>/{exam.maxScore}</Text>
  </View>
            <Text style={styles.scorePercentage}>
    {((exam.score / exam.maxScore) * 100).toFixed(0)}% Correct
            </Text>
          </View>
   <View style={styles.scoreMeter}>
            <View
              style={[
  styles.meterFill,
          {
    width: `${(exam.score / exam.maxScore) * 100}%`,
              backgroundColor:
         exam.score > 1400 ? '#4CAF50' : '#FF9800',
        },
              ]}
      />
 </View>
        </View>

        {/* Section Results */}
   <Text style={styles.sectionTitle}>Section Breakdown</Text>
        <View style={styles.sectionsContainer}>
          {exam.sections.map((section, index) => {
const details = sectionDetails[section];
    const accuracy = getAccuracy(details.correct, details.total);

   return (
    <TouchableOpacity
           key={index}
          style={styles.sectionCard}
onPress={() =>
           setSelectedSection(
       selectedSection === section ? null : section
  )
         }
  >
                <View style={styles.sectionHeader}>
          <View>
       <Text style={styles.sectionName}>{section}</Text>
           <Text style={styles.sectionScore}>
   {details.correct}/{details.total} Correct
     </Text>
       </View>
          <View style={styles.accuracyBadge}>
     <Text style={styles.accuracyText}>{accuracy}%</Text>
  </View>
    </View>

       <View style={styles.progressBar}>
          <View
style={[
        styles.progressFill,
       { width: `${accuracy}%` },
              ]}
           />
  </View>

                {selectedSection === section && (
       <View style={styles.expandedContent}>
        <View style={styles.statsGrid}>
     <View style={styles.statItem}>
        <Text style={styles.statLabel}>Avg Time</Text>
     <Text style={styles.statValue}>
              {details.avgTime} min
  </Text>
 </View>
 </View>

<View style={styles.topicsContainer}>
   <Text style={styles.topicsTitle}>Topics Covered:</Text>
          {details.topics.map((topic, idx) => (
    <View key={idx} style={styles.topicBadge}>
        <Ionicons
           name="checkmark-circle"
            size={14}
           color="#4CAF50"
   />
     <Text style={styles.topicText}>{topic}</Text>
  </View>
               ))}
       </View>
    </View>
         )}
      </TouchableOpacity>
         );
      })}
        </View>

        {/* Recommendations */}
        <Text style={styles.sectionTitle}>Recommendations</Text>
        <View style={styles.recommendationsContainer}>
          <View style={styles.recommendationCard}>
  <Ionicons name="bulb" size={24} color="#FFC107" />
        <View style={styles.recommendationContent}>
              <Text style={styles.recommendationTitle}>Focus Areas</Text>
        <Text style={styles.recommendationText}>
        Improve your Reading section by practicing more passages
          </Text>
        </View>
          </View>

          <View style={styles.recommendationCard}>
            <Ionicons name="time" size={24} color="#2196F3" />
            <View style={styles.recommendationContent}>
 <Text style={styles.recommendationTitle}>Time Management</Text>
  <Text style={styles.recommendationText}>
        Allocate more time to Math problems for better accuracy
  </Text>
  </View>
          </View>

    <View style={styles.recommendationCard}>
    <Ionicons name="book" size={24} color="#4CAF50" />
            <View style={styles.recommendationContent}>
         <Text style={styles.recommendationTitle}>Study Resources</Text>
  <Text style={styles.recommendationText}>
    Use our practice quizzes to strengthen weak topics
  </Text>
     </View>
          </View>
        </View>

        {/* Action Buttons */}
  <View style={styles.actionButtons}>
          <TouchableOpacity style={styles.button}>
     <Ionicons name="download" size={20} color="#FFFFFF" />
  <Text style={styles.buttonText}>Download PDF</Text>
          </TouchableOpacity>
        <TouchableOpacity style={[styles.button, styles.buttonSecondary]}>
      <Ionicons name="share-social" size={20} color="#2196F3" />
      <Text style={[styles.buttonText, styles.buttonTextSecondary]}>
 Share Results
     </Text>
 </TouchableOpacity>
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
  examTitle: {
fontSize: 22,
    fontWeight: 'bold',
    color: '#FFFFFF',
  },
  examDate: {
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
    elevation: 2,
  },
  scoreMain: {
    marginBottom: 16,
  },
  scoreLabel: {
    fontSize: 12,
    color: '#999',
    fontWeight: '500',
  },
  scoreRow: {
    flexDirection: 'row',
    alignItems: 'flex-start',
    marginTop: 4,
  },
  mainScore: {
    fontSize: 48,
    fontWeight: 'bold',
    color: '#2196F3',
  },
  maxScore: {
    fontSize: 20,
    color: '#999',
 marginTop: 8,
    marginLeft: 4,
  },
  scorePercentage: {
    fontSize: 14,
    color: '#666',
    marginTop: 8,
  },
  scoreMeter: {
 height: 8,
    backgroundColor: '#E0E0E0',
    borderRadius: 4,
    overflow: 'hidden',
  },
  meterFill: {
    height: '100%',
    borderRadius: 4,
  },
  sectionTitle: {
    fontSize: 16,
    fontWeight: '600',
    marginBottom: 12,
    marginLeft: 20,
    marginTop: 8,
    color: '#333',
  },
  sectionsContainer: {
    marginHorizontal: 16,
    marginBottom: 24,
  },
  sectionCard: {
    marginBottom: 12,
    paddingVertical: 16,
    paddingHorizontal: 14,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    elevation: 1,
  },
  sectionHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 10,
  },
  sectionName: {
    fontSize: 14,
    fontWeight: '600',
 color: '#333',
  },
  sectionScore: {
    fontSize: 12,
    color: '#999',
  marginTop: 2,
  },
  accuracyBadge: {
    paddingHorizontal: 12,
    paddingVertical: 6,
    backgroundColor: '#E3F2FD',
    borderRadius: 8,
  },
  accuracyText: {
    fontSize: 13,
    fontWeight: '600',
    color: '#2196F3',
  },
  progressBar: {
    height: 6,
    backgroundColor: '#E0E0E0',
    borderRadius: 3,
    overflow: 'hidden',
    marginBottom: 10,
  },
  progressFill: {
    height: '100%',
    backgroundColor: '#4CAF50',
    borderRadius: 3,
  },
  expandedContent: {
    marginTop: 12,
    paddingTop: 12,
    borderTopWidth: 1,
    borderTopColor: '#E0E0E0',
  },
  statsGrid: {
    flexDirection: 'row',
    marginBottom: 12,
  },
  statItem: {
    flex: 1,
    alignItems: 'center',
    paddingVertical: 8,
    backgroundColor: '#F5F5F5',
    borderRadius: 6,
  },
  statLabel: {
    fontSize: 11,
    color: '#999',
  },
  statValue: {
    fontSize: 14,
    fontWeight: '600',
    color: '#333',
    marginTop: 4,
  },
  topicsContainer: {
    marginTop: 8,
  },
  topicsTitle: {
    fontSize: 12,
    fontWeight: '600',
    color: '#333',
    marginBottom: 8,
  },
  topicBadge: {
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: 6,
    paddingHorizontal: 8,
    backgroundColor: '#F0F8FF',
    borderRadius: 6,
    marginBottom: 6,
    gap: 6,
  },
  topicText: {
    fontSize: 12,
    color: '#333',
  },
  recommendationsContainer: {
    marginHorizontal: 16,
    marginBottom: 24,
  },
  recommendationCard: {
 flexDirection: 'row',
    paddingVertical: 12,
    paddingHorizontal: 14,
    backgroundColor: '#FFFFFF',
    borderRadius: 10,
    marginBottom: 10,
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
  actionButtons: {
 flexDirection: 'row',
    marginHorizontal: 16,
    marginBottom: 24,
    gap: 10,
  },
  button: {
 flex: 1,
    flexDirection: 'row',
    paddingVertical: 12,
    backgroundColor: '#2196F3',
 borderRadius: 8,
    alignItems: 'center',
    justifyContent: 'center',
    gap: 8,
  },
  buttonSecondary: {
    backgroundColor: '#FFFFFF',
    borderWidth: 2,
    borderColor: '#2196F3',
  },
  buttonText: {
    fontSize: 13,
    fontWeight: '600',
    color: '#FFFFFF',
  },
  buttonTextSecondary: {
    color: '#2196F3',
  },
});

export default ExamDetailScreen;
