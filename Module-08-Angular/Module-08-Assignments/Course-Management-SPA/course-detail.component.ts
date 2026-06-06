import { Component, Input } from '@angular/core';
import { Course } from './course-list.component';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: [] // Keeping layout light for the submission portfolio
})
export class CourseDetailComponent {
  // The @Input() decorator acts as an entry gate. 
  // It allows the parent component (CourseListComponent) to drop the selected course details 
  // straight down here using property binding: [course]="selectedCourse".
  @Input() course: Course | null = null;

  constructor() {
    // Intern study note: Child component constructor. Inputs are not available yet!
  }
}
