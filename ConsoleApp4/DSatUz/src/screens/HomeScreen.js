import React from 'react';
import {
  View,
  Text,
  ScrollView,
  TouchableOpacity,
  StyleSheet,
  SafeAreaView,
} from 'react-native';
import { Ionicons } from '@expo/vector-icons';

const HomeScreen = ({ navigation }) => {
  const stats = {
    examsViewed: 5,
    questionsAnswered: 245,
    averageScore: 87,
  };

  const quickActions = [
    { title: 'Browse Exams', icon: 'document-text', color: '#FF6B6B', screen: 'Exams' },
    { title: 'Practice', icon: 'pencil', color: '#4ECDC4', screen: 'Practice' },
    { title: 'View Progress', icon: 'stats-chart', color: '#45B7D1', screen: 'Progress' },
    { title: 'Study Tips', icon: 'bulb', color: '#FFA502', action: 'tips' },
  ];

  return (
    <SafeAreaView style={styles.container}>
      <ScrollView showsVerticalScrollIndicator={false}>
        {/* Header */}
      <View style={styles.header}>
   <Text style={styles.title}>Welcome to DSatUz</Text>
          <Text style={styles.subtitle}>Your SAT Exam Preparation Hub</Text>
        </View>

        {/* Stats Cards */}
        <View style={styles.statsContainer}>
          <View style={[styles.statCard, { backgroundColor: '#E3F2FD' }]}>
          <Text style={styles.statNumber}>{stats.examsViewed}</Text>
            <Text style={styles.statLabel}>Exams Viewed</Text>
          </View>
          <View style={[styles.statCard, { backgroundColor: '#F3E5F5' }]}>
   <Text style={styles.statNumber}>{stats.questionsAnswered}</Text>
            <Text style={styles.statLabel}>Questions</Text>
          </View>
  <View style={[styles.statCard, { backgroundColor: '#E8F5E9' }]}>
   <Text style={styles.statNumber}>{stats.averageScore}%</Text>
            <Text style={styles.statLabel}>Avg Score</Text>
   </View>
        </View>

        {/* Quick Actions */}
        <Text style={styles.sectionTitle}>Quick Actions</Text>
   <View style={styles.actionsGrid}>
          {quickActions.map((action, index) => (
        <TouchableOpacity
     key={index}
   style={[styles.actionCard, { borderLeftColor: action.color }]}
     onPress={() => action.screen && navigation.navigate(action.screen)}
            >
 <Ionicons name={action.icon} size={32} color={action.color} />
         <Text style={styles.actionTitle}>{action.title}</Text>
     </TouchableOpacity>
          ))}
    </View>

        {/* Featured Section */}
        <Text style={styles.sectionTitle}>Featured</Text>
 <View style={styles.featuredCard}>
      <View style={styles.featuredBadge}>
            <Text style={styles.badgeText}>NEW</Text>
          </View>
          <Text style={styles.featuredTitle}>2024 SAT Practice Tests</Text>
          <Text style={styles.featuredDescription}>
 Get access to the latest practice exams and improve your score
          </Text>
   <TouchableOpacity style={styles.featuredButton}>
            <Text style={styles.featuredButtonText}>Explore</Text>
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
    paddingVertical: 24,
    backgroundColor: '#2196F3',
  },
  title: {
    fontSize: 28,
    fontWeight: 'bold',
  color: '#FFFFFF',
    marginBottom: 4,
  },
  subtitle: {
    fontSize: 14,
    color: 'rgba(255, 255, 255, 0.8)',
  },
  statsContainer: {
    flexDirection: 'row',
    paddingHorizontal: 10,
    marginTop: -30,
    marginBottom: 24,
    justifyContent: 'space-between',
  },
  statCard: {
    flex: 1,
    marginHorizontal: 8,
    paddingVertical: 16,
    borderRadius: 12,
  alignItems: 'center',
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.1,
    shadowRadius: 4,
  },
  statNumber: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#2196F3',
    marginBottom: 4,
  },
  statLabel: {
 fontSize: 12,
    color: '#666',
    textAlign: 'center',
  },
  sectionTitle: {
  fontSize: 18,
    fontWeight: '600',
    marginBottom: 12,
    marginLeft: 20,
    color: '#333',
  },
  actionsGrid: {
    flexDirection: 'row',
    flexWrap: 'wrap',
    paddingHorizontal: 10,
    marginBottom: 24,
  },
  actionCard: {
    width: '48%',
    paddingVertical: 16,
    paddingHorizontal: 12,
    backgroundColor: '#FFFFFF',
    borderRadius: 12,
    marginHorizontal: '1%',
    marginBottom: 12,
    alignItems: 'center',
    borderLeftWidth: 4,
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.08,
    shadowRadius: 4,
  },
  actionTitle: {
    marginTop: 8,
  fontSize: 12,
    fontWeight: '600',
    color: '#333',
    textAlign: 'center',
  },
  featuredCard: {
    marginHorizontal: 20,
    marginBottom: 24,
    paddingVertical: 16,
    paddingHorizontal: 16,
    backgroundColor: 'linear-gradient(135deg, #667eea 0%, #764ba2 100%)',
    borderRadius: 12,
    elevation: 3,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 3 },
    shadowOpacity: 0.2,
    shadowRadius: 6,
  },
  featuredBadge: {
    alignSelf: 'flex-start',
backgroundColor: '#FF6B6B',
    paddingHorizontal: 8,
    paddingVertical: 4,
    borderRadius: 4,
    marginBottom: 8,
  },
  badgeText: {
 color: '#FFFFFF',
    fontSize: 10,
    fontWeight: 'bold',
  },
  featuredTitle: {
    fontSize: 18,
    fontWeight: 'bold',
 color: '#FFFFFF',
    marginBottom: 8,
  },
  featuredDescription: {
    fontSize: 13,
color: 'rgba(255, 255, 255, 0.9)',
    marginBottom: 12,
    lineHeight: 20,
  },
  featuredButton: {
    marginTop: 8,
    paddingVertical: 10,
    backgroundColor: 'rgba(255, 255, 255, 0.3)',
    borderRadius: 6,
    alignItems: 'center',
  },
  featuredButtonText: {
    color: '#FFFFFF',
    fontWeight: '600',
  },
});

export default HomeScreen;
