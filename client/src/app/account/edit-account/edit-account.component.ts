import { Component, OnInit } from '@angular/core';
import { UserProfile } from 'src/app/shared/models/userProfile';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-edit-account',
  templateUrl: './edit-account.component.html',
  styleUrls: ['./edit-account.component.scss']
})
export class EditAccountComponent implements OnInit {
  userProfile: UserProfile = {
    email: '',
    displayName: '',
    token: '',
    address: {
      // Initialize properties of the 'Address' type if necessary
      firstName: '',
      lastName: '',
      phone: '',
      birthday: '',
      favoriteExhibit: '',
      city: ''
    }
  };
  constructor(private profileService: ProfileService) {
    
  }

  ngOnInit(): void {
    this.loadUserProfile();
  }

  loadUserProfile(): void {
    this.profileService.getUserProfile().subscribe((profile) => {
      this.userProfile = profile;
    });
  }

  updateProfile(): void {
    this.profileService.updateUserProfile(this.userProfile).subscribe(() => {
      // Handle success, e.g., show a success message
      console.log('Profile updated successfully');
    });
  }
}
