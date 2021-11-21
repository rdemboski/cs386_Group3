# 1. Introduction
SocialSquare is an event planning website that allows young adults and more to plan and
attend events, with the addition of a rating system that allows users to make informed
choices. Our website we have created allows a user to go in and sign up as either a host or an
attendee. When signing up the user is required to provide some basic information
(username, Name, password, location, zip code, host/not host). If you sign up as an
attendee you will have the ability to access the events page and view all current listed
events as well as access your account and the support page to create a ticket.. If you sign
up as a host you have the ability to create and delete events as well as all abilities given to
the attendee. Another feature we added was the ability for all registered users to filter events based off of their respective area codes. Lastly we created a home page that gives the user an introduction to Social Square and allows for easy navigation throughout the rest of the website.


# 2. Implemented Requirements
- Requirement: Users can create and manage their account \
 Issue: https://trello.com/c/UV4Owc9t/ \
 Pull Request: https://github.com/rdemboski/cs386_Group3/pull/50 \
 Implemented by: Brett Lewerke \
 Approved by: Ryan Demboski

- Requirement: Users can edit their accounts \
 Issue: https://trello.com/c/UV4Owc9t/ \
 Pull Request: https://github.com/rdemboski/cs386_Group3/pull/60 \
 Implemented by: Monika Beckham \
 Approved by: Ryan Demboski

- Requirement: Users can rate hosts \
 Issue: https://trello.com/c/Iei2OKVi/ \
 Pull Request: \
 Implemented by: \
 Approved by: 

- Requirement: Users can add other users to their followers/favorites list \
 Issue: https://trello.com/c/L5JFlN20/31-implement-favoriting-following \
 Pull Request: https://github.com/rdemboski/cs386_Group3/pull/56 \
 Implemented by: Monika Beckham \
 Approved by: Shayne Sellner

- Requirement: Events are linked to the host account user that made the event \
 Issue: https://trello.com/c/35XR05LN/ \
 Pull Request: https://github.com/rdemboski/cs386_Group3/pull/51 \
 Implemented by: Ryan Demboski \
 Approved by: Brett Lewerke


# 3. Tests
- xUnit
- https://github.com/rdemboski/cs386_Group3/tree/main/PartyTest



# 4. Demo



# 5. Code Quality
For our code, we decided to have these policies:
   - Model-View-Controller (MVC) design pattern
   - Keep all use-case code handled by the controller for the corresponding use-case
   - Make CSS and styling consistent throughout the website
   - Provide comments in the code when needed
   - All code was reviewed by pull requests before being committed to the repository
   - Strictly made functions that followed this template:
      ```c#
      public int dummy(int input)
         {
             return 0;
         }
      ```


# 6. Lessons Learned
We took our lessons learned from our experiences with developing the MVP for Deliverable 4 and had a smoother experience this time around. Because we were all more familiar with the adopted technologies, everyone was able to implement the more complicated requirements that we didn't have time for with the MVP. If we were to continue developing Social Square, a possible change we could make is to replace all of the hardcoded html and css for a modern framework that can assist in making our webpages look better, with less effort. None of us were very fond of painstakingly making all of our css from scratch. We would also look to make the website more secure for our users and add more polish/features to our various kinds of forms, such as having better filters for what a form can and cannot accept to the database.