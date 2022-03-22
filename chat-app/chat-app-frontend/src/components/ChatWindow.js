import React from "react";
import Message from "./Message";
import jwtDecode from "jwt-decode";

// Accepts the current channel name as props
// Uses channel name to make api request and render messages from current channel
const ChatWindow = ({ channelMessages }) => {
  const token = localStorage.getItem("token");
  const usernameClaim = jwtDecode(token).sub; // grab username from the 'sub' claim
  return (
    <div className="container inline-flex flex-col">
      {channelMessages.map((message, index) => {
        return (
          <div
            key={index}
            {...(message.username === usernameClaim
              ? { className: "self-end" }
              : { className: "self-start" })}
          >
            <Message text={message.text} username={message.username} />
          </div>
        );
      })}
    </div>
  );
};

export default ChatWindow;
