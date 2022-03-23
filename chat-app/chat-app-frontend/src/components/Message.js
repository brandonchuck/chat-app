import React from "react";

const Message = ({ username, text }) => {
  return (
    <div className="bg-blue-500 rounded-xl py-1 px-2 my-1 text-slate-100">
      <div className="text-left">{text}</div>
      <small className="text-right">{username}</small>
    </div>
  );
};

export default Message;
