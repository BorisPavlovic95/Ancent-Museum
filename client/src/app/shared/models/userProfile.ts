export interface UserProfile {
  email: string;
  displayName: string;
  token: string;
  address: AddressDto;
}

export interface AddressDto {
  firstName: string;
  lastName: string;
  phone: string;
  birthday: string;
  favoriteExhibit: string;
  city: string;
}