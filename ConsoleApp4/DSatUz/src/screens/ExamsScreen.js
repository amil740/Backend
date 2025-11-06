import React, { useState } from 'react';
import {
  View,
  Text,
  ScrollView,
  TouchableOpacity,
  StyleSheet,
  SafeAreaView,
  FlatList,
  Modal,
  ActivityIndicator,
} from 'react-native';
import { Ionicons } from '@expo/vector-icons';

const ExamsScreen = ({ navigation }) => {
  const [exams, setExams] = useState([
    {
      id: '1',
      title: '2024 SAT Test 1',
      date: 'March 2024',
      score: 1420,
      maxScore: 1600,
      sections: ['Reading', 'Writing', 'Math'],
    },
    {
      id: '2',
      title: '2024 SAT Test 2',
 date: 'April 2024',
      score: 1450,
      maxScore: 1600,
      sections: ['Reading', 'Writing', 'Math'],
    },
    {
      id: '3',
   title: '2023 SAT Test 1',
      date: 'December 2023',
      score: 1380,
      maxScore: 1600,
      sections: ['Reading', 'Writing', 'Math'],
    },
    {
      id: '4',
      title: '2023 SAT Test 2',
      date: 'October 2023',
      score: 1410,
      maxScore: 1600,
      sections: ['Reading', 'Writing', 'Math'],
    },
    {
      id: '5',
      title: '2023 SAT Test 3',
      date: 'August 2023',
      score: 1390,
      maxScore: 1600,
      sections: ['Reading', 'Writing', 'Math'],
    },
  ]);

  const [loading, setLoading] = useState(false);
  const [selectedExam, setSelectedExam] = useState(null);

  const handleExamPress = (exam) => {
setLoading(true);
    setTimeout(() => {
      setLoading(false);
      navigation.navigate('ExamDetail', { exam });
    }, 800);
  };

  const getScoreColor = (score, maxScore) => {
    const percentage = (score / maxScore) * 100;
    if (percentage >= 90) return '#4CAF50';
    if (percentage >= 75) return '#FFC107';
    return '#FF9800';
  };

  const ExamCard = ({ exam }) => {
    const percentage = (exam.score / exam.maxScore) * 100;
    const color = getScoreColor(exam.score, exam.maxScore);

    return (
      <TouchableOpacity
        style={styles.examCard}
        onPress={() => handleExamPress(exam)}
      >
        <View style={styles.examHeader}>
<View>
  <Text style={styles.examTitle}>{exam.title}</Text>
   <Text style={styles.examDate}>{exam.date}</Text>
    </View>
    <Ionicons name="chevron-forward" size={24} color="#999" />
        </View>

        <View style={styles.scoreSection}>
     <View style={styles.scoreCircle}>
 <Text style={[styles.scoreText, { color }]}>
      {percentage.toFixed(0)}%
      </Text>
       <Text style={styles.scoreLabel}>Score</Text>
          </View>
          <View style={styles.scoreDetails}>
 <Text style={styles.scoreValue}>
         {exam.score} / {exam.maxScore}
      </Text>
      <View style={styles.progressBar}>
          <View
    style={[
  styles.progressFill,
   { width: `${percentage}%`, backgroundColor: color },
            ]}
      />
        </View>
      </View>
        </View>

        <View style={styles.sectionsContainer}>
   {exam.sections.map((section, index) => (
  <View key={index} style={styles.sectionBadge}>
          <Text style={styles.sectionText}>{section}</Text>
            </View>
        ))}
        </View>
      </TouchableOpacity>
    );
  };

  return (
    <SafeAreaView style={styles.container}>
      <ScrollView showsVerticalScrollIndicator={false}>
        <View style={styles.header}>
        <Text style={styles.headerTitle}>Past SAT Exams</Text>
<Text style={styles.headerSubtitle}>
     {exams.length} exams available
          </Text>
        </View>

      <View style={styles.filterContainer}>
          <TouchableOpacity style={styles.filterButton}>
    <Ionicons name="funnel" size={20} color="#2196F3" />
  <Text style={styles.filterText}>Filter</Text>
 </TouchableOpacity>
 <TouchableOpacity style={styles.sortButton}>
            <Ionicons name="swap-vertical" size={20} color="#2196F3" />
 <Text style={styles.sortText}>Sort</Text>
          </TouchableOpacity>
        </View>

    {exams.map((exam) => (
          <ExamCard key={exam.id} exam={exam} />
   ))}

        <View style={styles.uploadSection}>
   <TouchableOpacity style={styles.uploadButton}>
   <Ionicons name="cloud-upload" size={32} color="#2196F3" />
            <Text style={styles.uploadText}>Upload Exam PDF</Text>
        <Text style={styles.uploadSubtext}>Add your own exam files</Text>
          </TouchableOpacity>
        </View>
      </ScrollView>

      <Modal visible={loading} transparent={true}>
        <View style={styles.loadingContainer}>
          <ActivityIndicator size="large" color="#2196F3" />
          <Text style={styles.loadingText}>Loading exam...</Text>
        </View>
      </Modal>
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
  filterContainer: {
    flexDirection: 'row',
    paddingHorizontal: 20,
    paddingVertical: 12,
    gap: 8,
  },
  filterButton: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: 8,
    paddingHorizontal: 12,
    backgroundColor: '#FFFFFF',
    borderRadius: 8,
 gap: 8,
  },
  filterText: {
    fontSize: 14,
  fontWeight: '500',
    color: '#2196F3',
  },
  sortButton: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: 8,
    paddingHorizontal: 12,
    backgroundColor: '#FFFFFF',
    borderRadius: 8,
    gap: 8,
  },
  sortText: {
  fontSize: 14,
    fontWeight: '500',
    color: '#2196F3',
  },
  examCard: {
    marginHorizontal: 16,
    marginVertical: 8,
    paddingVertical: 16,
    paddingHorizontal: 16,
    backgroundColor: '#FFFFFF',
    borderRadius: 12,
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.1,
    shadowRadius: 4,
  },
  examHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 12,
  },
  examTitle: {
    fontSize: 16,
  fontWeight: '600',
    color: '#333',
  },
  examDate: {
    fontSize: 12,
    color: '#999',
    marginTop: 4,
  },
  scoreSection: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 12,
    gap: 16,
  },
  scoreCircle: {
    width: 70,
    height: 70,
    borderRadius: 35,
    backgroundColor: '#F5F5F5',
    justifyContent: 'center',
    alignItems: 'center',
  },
  scoreText: {
    fontSize: 20,
    fontWeight: 'bold',
  },
  scoreLabel: {
    fontSize: 10,
    color: '#999',
 marginTop: 2,
  },
  scoreDetails: {
  flex: 1,
  },
  scoreValue: {
    fontSize: 14,
    fontWeight: '600',
    color: '#333',
    marginBottom: 6,
  },
  progressBar: {
    height: 8,
    backgroundColor: '#E0E0E0',
    borderRadius: 4,
    overflow: 'hidden',
  },
  progressFill: {
    height: '100%',
    borderRadius: 4,
  },
  sectionsContainer: {
    flexDirection: 'row',
    gap: 8,
    flexWrap: 'wrap',
  },
  sectionBadge: {
    paddingHorizontal: 12,
  paddingVertical: 6,
    backgroundColor: '#E3F2FD',
    borderRadius: 16,
  },
  sectionText: {
    fontSize: 11,
    fontWeight: '500',
    color: '#2196F3',
  },
  uploadSection: {
    paddingHorizontal: 20,
    paddingVertical: 24,
  },
  uploadButton: {
    paddingVertical: 32,
    paddingHorizontal: 20,
    backgroundColor: '#FFFFFF',
  borderRadius: 12,
    borderStyle: 'dashed',
borderWidth: 2,
    borderColor: '#2196F3',
    alignItems: 'center',
    justifyContent: 'center',
  },
  uploadText: {
    fontSize: 16,
    fontWeight: '600',
    color: '#2196F3',
    marginTop: 8,
  },
  uploadSubtext: {
    fontSize: 12,
    color: '#999',
    marginTop: 4,
  },
  loadingContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
  },
  loadingText: {
    marginTop: 12,
    color: '#2196F3',
    fontWeight: '600',
  },
});

export default ExamsScreen;
